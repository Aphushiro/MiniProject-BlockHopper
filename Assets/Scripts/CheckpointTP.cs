using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTP : MonoBehaviour
{
    public Vector3 restartPoint = new Vector3(0, 0, 0);

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            // "Restarts" character controller to avoid interfering with resetting chaCon calculations
            // The sets position to a chosen checkpoint position
            CharacterController chaCon = other.gameObject.GetComponent<PlayerMovement>().controller;
            chaCon.enabled = false;
            other.transform.position = restartPoint;
            chaCon.enabled = true;
        }
    }
}
