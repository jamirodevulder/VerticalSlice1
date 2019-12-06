using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private float cameraSpeed = 0;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Vector3 fortPositionX;
    [SerializeField] private Vector3 birdPositionX;
    [SerializeField] public float dist =1;
    [SerializeField] GameObject achtergrond;
    [SerializeField] GameObject achtergrondGrass;
    [SerializeField] GameObject fortGrond;
    [SerializeField] GameObject birdgrond;
    [SerializeField] GameObject voorGrondGrass;
    




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
        /*if (Input.GetKeyDown(Constante.q))
        {
            StartCoroutine(MoveToFort());
        }
        if (Input.GetKeyUp(Constante.q))
        {
            StartCoroutine(MoveToBird());
        }*/
    }


    public IEnumerator MoveToBird()
    {
        
            yield return new WaitForSeconds(3);
        while ( transform.position.x > birdPositionX.x)
        {
            yield return new WaitForSeconds(0.0001f);
            transform.position -= new Vector3(cameraSpeed, 0);
            achtergrond.transform.position -= new Vector3(cameraSpeed/2, 0);

        }

    }

    public IEnumerator MoveToFort()
    {
        dist = 1;
        while (transform.position.x < fortPositionX.x)
        {
            yield return new WaitForSeconds(0.0001f);
            dist -= (Time.deltaTime * 2) * dist;
            this.transform.position = Vector3.Lerp(new Vector3(fortPositionX.x, 0, fortPositionX.z), new Vector3(birdPositionX.x, 0, birdPositionX.z), dist);
            achtergrond.transform.position = Vector3.Lerp(new Vector3(achtergrond.transform.position.x, achtergrond.transform.position.y, 1), new Vector3(-2.43, achtergrond.transform.position.y, 1), dist);

            if (dist <= 0.01)
            {
                dist = 0;
            }
        }
    }

  

}
