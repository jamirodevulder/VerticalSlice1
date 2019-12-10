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
    [SerializeField] private ScoreScript scoreScript;
    private float objectHealt;
    private int index = 0;
    private bool getDamage = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitBeforeDamaged());
        objectHealt = maxhealt;
        scoreScript = GameObject.Find("HighScoreText").GetComponent<ScoreScript>();
    }
    private IEnumerator waitBeforeDamaged()
    {
        yield return new WaitForSeconds(5f);
        getDamage = true;
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
                scoreScript.AddScore(5000);
                Destroy(this.gameObject);
            }

        }
        if(this.gameObject.transform.position.y < -10)
        {
            setObjectHealt(objectHealt);
        }

    }
    public void setObjectHealt(float healt)
    {
        if (getDamage)
        {
            objectHealt -= healt;
            scoreScript.AddScore(healt * 75);
        }
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
