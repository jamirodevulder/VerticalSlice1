using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] public float maxhealt;
    [SerializeField] public float[] healtStages;
    [SerializeField] private Sprite[] stagesSprites;
    [SerializeField] private ParticleSystem[] systems;
    [SerializeField] private GameObject particleRemover;
    [SerializeField] private bool PigAnimationPlay = false;
    [SerializeField] private Animator dead;
    [SerializeField] private particleSystemPlayScript AnimPlay;
    private float objectHealt;
    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        objectHealt = maxhealt;
    }

    // Update is called once per frame
    void Update()
    {
        if(objectHealt <= healtStages[index])
        {
            
             if (index < healtStages.Length)
            {

                gameObject.GetComponent<SpriteRenderer>().sprite = stagesSprites[index];
                if (index < healtStages.Length -1)
                {
                    index++;
                }
            }
        }

        if (objectHealt <= 0)
        {
            for (int i = 0; i < systems.Length; i++)
            {
                systems[i].Play();
            }
            if (!PigAnimationPlay)
            {
                particleRemover.GetComponent<removeParticles>().removeParticleSystem(systems[0]);
                Destroy(this.gameObject);
            }
            else
            {
                AnimPlay.playParticle("dead");
                Destroy(this.gameObject);
            }

        }


    }
    public void setObjectHealt(float healt)
    {
        objectHealt -= healt;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            objectHealt -= collision.relativeVelocity.magnitude;
            print(objectHealt);
        }
        if(collision.gameObject.tag == "egg")
        {
           // objectHealt -= collision.relativeVelocity.magnitude;
        }
        if(collision.gameObject.tag == "object")
        {
            objectHealt -= collision.relativeVelocity.magnitude / 2;
         
        }
        if (collision.gameObject.tag == "ground")
        {
            float velocityY = gameObject.GetComponent<Rigidbody2D>().velocity.y * 1;
            objectHealt -= velocityY;

        }
    }
}
