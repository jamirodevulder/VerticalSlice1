using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private CameraScript cameraScript;
    [SerializeField] private bird[] birdScript;
    [SerializeField] private ScoreScript pigsdown;
    private ExplosionForce explosionScript;
    private ParticleBird particleScript;
    [SerializeField] RopeScript slingshot;
    [SerializeField] private GameObject[] birdsposition;
    private bool birdisShot;
    private bool cameraMove = true;
    private int index = 0;
    [SerializeField] private GameObject[] pigs;
    private int pigDeath;
    private bool pigsDontMove = true;
    [SerializeField] PauseButton win;


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
                if (index < birdScript.Length)
                {
                    index++;
                }
                CameraMoveToBirds();
                
            }
        }
        print(index);
        if (index == birdScript.Length && pigDeath < pigs.Length - 1)
        {
          
           StartCoroutine(WaitForLose());
                             
        }
        countPig();
      

       
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

    private IEnumerator WaitForLose()
    {
        yield return new WaitForSeconds(3f);
        if (!win.gameWon)
        {
            pigsdown.allPigsDown = false;
            win.gameLose = true;
        }
    }
    private IEnumerator TimerNewBird()
    {
        yield return new WaitForSeconds(2);
        if (index != birdScript.Length)
        {
            slingshot.newBird(index);
        }
    }
    private void countPig()
    {
        pigDeath = 0;
        for (int i = 0; i < pigs.Length; i++)
        {
            if (pigs[i] == null)
            {
                pigDeath++;
                if (pigDeath == pigs.Length)
                {
                    win.gameWon = true;
                    
                }
            }
        }

    }
    
}
