using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private ScoreScript scoreScript;
    private Sprite enemy;
    
    private void Awake()
    {
        enemy = FindObjectOfType<Sprite>();
    }

    private void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.W))
        {
            scoreScript.AddScore(10);
            Destroy(this.gameObject);
        }
    }
}
