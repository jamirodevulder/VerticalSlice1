using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private CameraScript cameraScript;
    [SerializeField] private bird[] birdScript;
    private ExplosionForce explosionScript;
    private ParticleBird particleScript;
    [SerializeField] RopeScript slingshot;
    [SerializeField] private GameObject[] birdsposition;
    private bool birdisShot;
    private bool cameraMove = true;
    private int index = 0;


    private void Awake()
    {
        cameraScript = GameObject.Find(Constante.mainCamera).GetComponent<CameraScript>();
        
    }

    void Update()
    {
        if (index < birdScript.Length)
        {
            if (birdsposition[index] != null && birdsposition[index].transform.position.x >= -8)
            {
                print("test");
                CameraMoveToFort();

            }
            if (birdScript[index] == null)
            {
                index++;
                CameraMoveToBirds();
            }
        }

    }

    public void CameraMoveToFort()
    {
        
        StartCoroutine(cameraScript.MoveToFort());
        
    }
    public void CameraMoveToBirds()
    {
        StartCoroutine(TimerNewBird());
        StartCoroutine(cameraScript.MoveToBird());
        cameraScript.dist = 1;


    }
    private IEnumerator TimerNewBird()
    {
        yield return new WaitForSeconds(2);
        
        slingshot.newBird(index);
        
    }

    
}
