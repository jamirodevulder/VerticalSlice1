using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : UIScript
{
    [SerializeField] private PauseButton pauseScript;
    private void Awake()
    {
        mainCamera = FindObjectOfType<Camera>();
        transform.position = new Vector3(mainCamera.transform.position.x - 2f,mainCamera.transform.position.y + 1f,mainCamera.transform.position.z + 10);
    }
}
