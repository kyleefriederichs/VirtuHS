using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PoleScript : MonoBehaviour // replace as needed. It depends on how you have the gear attachment system set up
{
    
    public Gear attachedGear; // Reference to the currently attached gear
    void Update()
    {
        // for example, if when attaching the gear to this pole, you made the gear a child of this pole you could do this to get reference to it
        if (transform.GetChild(0) != null)
        {
            attachedGear = transform.GetChild(0).GetComponent<Gear>();
        }
        
    }

    public Gear GetAttachedGear()
    {
        return attachedGear;
    }
}