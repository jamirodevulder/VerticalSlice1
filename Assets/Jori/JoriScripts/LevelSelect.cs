using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : UIScript
{
    private void Awake()
    {
        GetComponentInChildren<Button>().onClick.AddListener(LevelSelectClicked);
    }

    void LevelSelectClicked()
    {

    }
}
