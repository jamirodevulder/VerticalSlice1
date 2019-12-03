using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Vector3 fortPositionX;
    [SerializeField] private Vector3 birdPositionX;
    [SerializeField] public float dist =1;



    private float pointsRadius;


    private void Start()
    {
        mainCamera.transform.position = fortPositionX;
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
        if (Input.GetKeyUp(Constante.q))
        {
            StartCoroutine(MoveToBird());
        }
    }


    public IEnumerator MoveToBird()
    {

            yield return new WaitForSeconds(3);
        while ( transform.position.x > birdPositionX.x)
        {
            yield return new WaitForSeconds(0.0000001f);
            transform.position -= new Vector3(0.1f, 0);
        }




      
    }

    public IEnumerator MoveToFort()
    {
        
        while (transform.position.x < fortPositionX.x)
        {
            yield return new WaitForSeconds(0.01f);
            dist -= (Time.deltaTime/10) * dist;
            this.transform.position = Vector3.Lerp(new Vector3(fortPositionX.x, 0, fortPositionX.z), new Vector3(birdPositionX.x, 0, birdPositionX.z), dist);
        }
 


    }

  

}
