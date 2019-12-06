using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Sprite enemy;
    [SerializeField] private PauseButton pauseScript;
    
    private void Awake()
    {
        enemy = FindObjectOfType<Sprite>();
    }

    private void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime); // Beweegt naar rechts
        if(Input.GetKeyDown(KeyCode.W))
        {
            pauseScript.buttonGameObjects[5].SetActive(true);
            pauseScript.buttonGameObjects[3].SetActive(true);
            pauseScript.buttonGameObjects[0].SetActive(true);
            pauseScript.gameWon = true;
            Destroy(this.gameObject);
            Destroy(this);
        }
    }
}