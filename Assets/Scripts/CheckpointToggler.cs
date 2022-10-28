using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointToggler : MonoBehaviour
{
    public bool setState = false;
    // Call ToggleCheckpoints in the managing checkpoint object's (the sphere's) InteractSwitch script
    private void OnTriggerEnter(Collider other)
    {
        GetComponentInParent<InteractSwitch>().ToggleCheckpoints(setState);
    }

}
