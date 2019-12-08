using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followObject : MonoBehaviour
{
    [SerializeField] GameObject theObjectToFollow;

    void Update()
    {
        if (theObjectToFollow != null)
        {
            transform.position = theObjectToFollow.transform.position;
        }
    }
}
