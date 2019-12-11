﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Vector3 fortPositionX;
    [SerializeField] private Vector3 birdPositionX;
    [SerializeField] public float dist =1;
    private bool move = false;


    private float pointsRadius;


    private void Start()
    {
        pointsRadius = fortPositionX.x - birdPositionX.x;
        StartCoroutine(MoveToBird());
        
    }
    private void Update()
    {
        Vector3 dis = transform.position - fortPositionX;
        float disMag = dis.magnitude;
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            StartCoroutine(MoveToFort());
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            print("test");
            StartCoroutine(MoveToBird());
        }
    }
     

    public IEnumerator MoveToBird()
    {

        yield return new WaitForSeconds(3.5f);
        while ( transform.position.x > birdPositionX.x)
        {
                move = true;
            yield return new WaitForSeconds(0.0000001f);
            transform.position -= new Vector3(0.3f, 0);
            if(transform.position.y > birdPositionX.y)
            {
                transform.position -= new Vector3(0, 0.03f);
            }
            if (mainCamera.orthographicSize >= 7)
            {
                mainCamera.orthographicSize -= 0.03f;

            }
        }

        dist = 1;
        move = false;

      
    }

    public IEnumerator MoveToFort()
    {
        
        while (transform.position.x < fortPositionX.x)
        {
            move = true;
            yield return new WaitForSeconds(0.01f);
            dist -= (Time.deltaTime*2) * dist;
            this.transform.position = Vector3.Lerp(new Vector3(fortPositionX.x, 2f, fortPositionX.z), new Vector3(birdPositionX.x, 1f, birdPositionX.z), dist);
            if (mainCamera.orthographicSize <= 8)
            {
                mainCamera.orthographicSize += 0.025f;

            }

        }

        move = false;

    }

  

}
