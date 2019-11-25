using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Return : MonoBehaviour
{
    private void Awake()
    {
        GetComponentInChildren<Button>().onClick.AddListener(ReturnKnop);
    }

    private void ReturnKnop()
    {
        SceneManager.LoadScene("JoriScene");
    }
}
