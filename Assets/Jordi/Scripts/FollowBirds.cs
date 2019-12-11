using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBirds : MonoBehaviour
{
    [SerializeField] public int followBird = 0;
    [SerializeField] public ParticleSystem unevenBirds;
    [SerializeField] public ParticleSystem evenBirds;
    [SerializeField] RopeScript slingshot;
    [SerializeField] GameManager gameManager;

    // Update is called once per frame
    private void Start()
    {
        unevenBirds.transform.position = slingshot.birds[0].GetComponentInChildren<Rigidbody2D>().transform.position;
        evenBirds.transform.position = slingshot.birds[1].GetComponentInChildren<Rigidbody2D>().transform.position;
    }
    void Update()
    {
        try
        {
            if (followBird <= 0 && slingshot.birds[gameManager.index] != null && slingshot.birds[gameManager.index].GetComponentInChildren<Rigidbody2D>() != null)
            {
                print(gameManager.index);
                unevenBirds.transform.position = slingshot.birds[gameManager.index].GetComponentInChildren<Rigidbody2D>().transform.position;
            }
            if (followBird == 1 && slingshot.birds[gameManager.index] != null && slingshot.birds[gameManager.index].GetComponentInChildren<Rigidbody2D>() != null)
            {
                evenBirds.transform.position = slingshot.birds[gameManager.index].GetComponentInChildren<Rigidbody2D>().transform.position;
            }
            if (followBird >= 2)
            {
                followBird = 0;
            }
        }
        catch(System.IndexOutOfRangeException ex)
        {
            print("lol");
        }
    }
}
