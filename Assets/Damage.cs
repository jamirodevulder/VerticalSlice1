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
     private float objectHealt;
    // Start is called before the first frame update
    void Start()
    {
        objectHealt = maxhealt;
    }

    // Update is called once per frame
    void Update()
    {
        if(healtStages[0] <= objectHealt)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = stagesSprites[0];
        }
        else if (healtStages[1] <= objectHealt)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = stagesSprites[1];
        }
        else if (healtStages[2] <= objectHealt)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = stagesSprites[2];
        }
        else if(objectHealt <= 0)
        {
            for(int i = 0; i < systems.Length; i++)
            {
                systems[i].Play();
            }
            particleRemover.GetComponent<removeParticles>().removeParticleSystem(systems[0]);
            Destroy(this.gameObject);
            
        }



    }
    public void setObjectHealt(float healt)
    {
        objectHealt -= healt;
        print(objectHealt);
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
            objectHealt -= collision.relativeVelocity.magnitude * 2;
        }
    }
}
