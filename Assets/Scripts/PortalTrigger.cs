using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalTrigger : MonoBehaviour
{
    public int levelIndex;
    // Changes scenes upon being triggered
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(levelIndex);
    }
}
