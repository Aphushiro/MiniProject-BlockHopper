using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointActivator : MonoBehaviour
{
    public GameObject resetBarriers;
    bool activated = false;

    // Activates connected "safety net" upon being triggered by the player object
    private void OnTriggerEnter(Collider other)
    {
        if (activated)
        {
            return;
        }
        resetBarriers.SetActive(true);
        Debug.Log(gameObject.name + " activated");
        activated = true;
    }
}
