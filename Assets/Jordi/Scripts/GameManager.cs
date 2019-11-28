using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private CameraScript cameraScript;
    private bird birdScript;
    private ExplosionForce explosionScript;
    private ParticleBird particleScript;
    private bool birdisShot;
    private int cameraMove = 0;


    private void Awake()
    {
        cameraScript = GameObject.Find(Constante.mainCamera).GetComponent<CameraScript>();
        birdScript = GameObject.Find(Constante.player).GetComponent<bird>();
    }

    void Update()
    {
        
        if (birdScript.shot&& cameraMove == 0)
        {
            CameraMoveToFort();
            cameraMove++;
        }
        

    }

    public void CameraMoveToFort()
    {
        StartCoroutine(cameraScript.MoveToFort());
    }

    
}
