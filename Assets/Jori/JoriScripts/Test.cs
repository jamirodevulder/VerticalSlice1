using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    private Button testButton;
    private void Awake()
    {
        testButton = GetComponent<Button>();
        AddListener(TestClick);
    }



    void AddListener(UnityEngine.Events.UnityAction call)
    {
        testButton.onClick.AddListener(call);
    }

    void TestClick()
    {
        Debug.Log("Test succesvol");
    }
}
