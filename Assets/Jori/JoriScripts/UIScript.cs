﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    protected Text buttonText;
    protected Button clickableButton;
    protected Vector3 returnPosition;
    protected Camera mainCamera;

    protected void AddListener(UnityEngine.Events.UnityAction call)
    {
        clickableButton = GetComponentInChildren<Button>();
        mainCamera = FindObjectOfType<Camera>();
        clickableButton.onClick.AddListener(call);
    }
}
