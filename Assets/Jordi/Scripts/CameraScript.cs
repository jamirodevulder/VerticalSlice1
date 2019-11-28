using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Vector3 fortPositionX;
    [SerializeField] private Vector3 birdPositionX;
    [SerializeField] private float dist =1;



    private float pointsRadius;
    [SerializeField] private Camera mainCamera;

    private void Start()
    {
        pointsRadius = fortPositionX.x - birdPositionX.x;
        StartCoroutine(MoveToBird());
        
    }
    private void Update()
    {
        Vector3 dis = transform.position - fortPositionX;
        float disMag = dis.magnitude;
        if (Input.GetKeyDown(Constante.q))
        {
            StartCoroutine(MoveToFort());
        }
    }


    public IEnumerator MoveToBird()
    {

            yield return new WaitForSeconds(3);
        while ( transform.position.x > birdPositionX.x)
        {
            yield return new WaitForSeconds(0.0000001f);
            transform.position -= new Vector3(0.3f, 0);
            
            if (mainCamera.orthographicSize >= 7)
            {
                mainCamera.orthographicSize -= 0.03f;

            }
        }


      
    }

    public IEnumerator MoveToFort()
    {
        while (transform.position.x < fortPositionX.x)
        {
            yield return new WaitForSeconds(0.01f);
            dist -= (Time.deltaTime*2) * dist;
            this.transform.position = Vector3.Lerp(new Vector3(fortPositionX.x, 1.9f, fortPositionX.z), new Vector3(birdPositionX.x, 1.9f, birdPositionX.z), dist);
            if (mainCamera.orthographicSize <= 8)
            {
                mainCamera.orthographicSize += 0.025f;

            }

        }


    }

  

}
