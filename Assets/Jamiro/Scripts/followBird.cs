using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followBird : MonoBehaviour
{
    [SerializeField] GameObject child;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (child != null)
        {
            transform.position = child.transform.position;
        }
    }
}
