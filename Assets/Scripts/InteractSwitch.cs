using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractSwitch : MonoBehaviour
{
    public GameObject[] activators;
    public Material offMat;
    public Material onMat;

    private void Start()
    {
        ToggleCheckpoints(true);
    }

    public void ToggleCheckpoints (bool isActive)
    {
        // Sets active state of every activator object to the "isActive" parameter
        // Also deactivates all safety nets
        for(int i = 0; i < activators.Length; i++)
        {
            activators[i].GetComponent<CheckpointActivator>().resetBarriers.SetActive(false);
            activators[i].SetActive(isActive);
        }
        Debug.Log("Checkpoints active: " + isActive);

        // Switches object material between red and green based on activation state
        switch (isActive)
        {
            case (false):
                gameObject.GetComponent<MeshRenderer>().material = offMat;
                break;
            default:
                gameObject.GetComponent<MeshRenderer>().material = onMat;
                break;
        }
    }

}
