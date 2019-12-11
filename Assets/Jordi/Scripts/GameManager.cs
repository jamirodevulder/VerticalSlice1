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
    [SerializeField] FollowBirds followBirds;
    [SerializeField] private GameObject[] birdsposition;
    private bool birdisShot;
    private bool cameraMove = true;
    public int index = 0;
    [SerializeField] private GameObject[] pigs;
    private int pigDeath;
    private bool pigsDontMove = true;
    [SerializeField] PauseButton win;
    public bool move = true;

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
                
                CameraMoveToFort();

            }
            if (birdScript[index] == null )
            {
                
                if (index < birdScript.Length)
                {
                    index++;
                }
                
                StartCoroutine(wait());

            }
        }

        if (index == birdScript.Length && pigDeath < pigs.Length - 1)
        {

           StartCoroutine(WaitForLose());
            

        }
        countPig();



    }
    public IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        CameraMoveToBirds();
        followBirds.followBird++;


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
        yield return new WaitForSeconds(2f);
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
