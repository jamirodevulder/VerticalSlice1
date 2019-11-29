using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private ScoreScript scoreScript;
    private Sprite enemy;
    
    private void Awake()
    {
        enemy = FindObjectOfType<Sprite>();
    }

    private void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime); // Beweegt naar rechts
        if(Input.GetKeyDown(KeyCode.W))
        {
            scoreScript.AddScore(400);
            Destroy(this.gameObject);
            Destroy(this);
        }
    }
}
