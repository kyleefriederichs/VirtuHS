using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class GearManager : MonoBehaviour
{
    [SerializeField] private List<PoleScript> poles = new List<PoleScript>(); // assuming the poles are in a fixed order
    [SerializeField] TMP_Text resultText; // Optional: UI Text to display the result

    private void Update()
    {
        if (AllGearsPlaced())
        {
            float ima = CalculateIMA();
            DisplayIMA(ima);
        }
        else
        {
            DisplayIMA(0); // Display "Incomplete" when not all gears are attached
        }
    }

    private bool AllGearsPlaced() // Check if each of the poles have a gear attached
    {
        for (int i = 0; i < poles.Count; i++)
        {
            Gear attachedGear = GetAttachedGear(poles[i]);
            if (attachedGear == null)
            {
                return false;
            }
        }
        return true;
    }

    private float CalculateIMA()
    {
        // Ensure there are at least 4 poles
        if (poles.Count < 4) return 0;

        // Get the attached gears from the first and fourth poles
        Gear firstGear = GetAttachedGear(poles[0]);
        Gear fourthGear = GetAttachedGear(poles[3]);

        // Prevent null reference or division by zero
        if (firstGear == null || fourthGear == null || firstGear.numberOfTeeth == 0)
            return 0;

        return (float)fourthGear.numberOfTeeth / firstGear.numberOfTeeth;
    }

    private void DisplayIMA(float ima)
    {
        if (resultText != null)
        {
            if (ima == 0)
            {
                resultText.text = "IMA: Incomplete - Place all gears.";
            }
            else
            {
                resultText.text = "IMA: " + ima.ToString("F2");
            }
        }
    }

    private Gear GetAttachedGear(PoleScript poleScript)
    {
        return poleScript != null ? poleScript.GetAttachedGear() : null;
    }
}
