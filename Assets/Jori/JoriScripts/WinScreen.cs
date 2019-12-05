using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : UIScript
{
    private void Awake()
    {
        mainCamera = FindObjectOfType<Camera>();
        transform.position = mainCamera.transform.position;
    }
}
