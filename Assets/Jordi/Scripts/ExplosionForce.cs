using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionForce : BirdClass
{
    [SerializeField] private float radius = 5.0F; // zorgt voor radius waar hij objecten aantast
    [SerializeField] private float power = 10.0F; // zorgt voor explosie power
    [SerializeField] private LayerMask obstacleLayer; // layer van obstacels zoals dozen
    [SerializeField] private LayerMask groundLayer; // layer van de vloer
    [SerializeField] private AudioSource explosieAudio; // audio die de explosie af speelt
    [SerializeField] private AudioClip explosie; // de explosie geluid
    [SerializeField] private AudioClip explosieTimer; // het aftikkende geluid
    [SerializeField] private bool canExplode = true; // kijk of hij objecten nog aangetast kunnen worden
    [SerializeField] private bool playTimer = true; // kijkt of hij klaar is met audio spelen
    [SerializeField] private bool startTimer = true; // kijkt of hij de audio mag spelen of gelijk moet exploderen
    private bool SpaceBarExplode = true;
    [SerializeField] private GameObject particleHandler;
    Collider2D[] colliders;
    Vector2 explosionPos = new Vector2(0,0);
    [SerializeField] Rigidbody2D playerRb;

    private void Start()
    {
        //playerRb.AddForce(new Vector2(300*playerRb.mass,45*playerRb.mass));
    }

    void Update()
    {

        Vector3 explosionPos = transform.position;  // zorgt er voor dat hij weet van waar hij de explosie moet schieten
        colliders = Physics2D.OverlapCircleAll(explosionPos, radius, obstacleLayer); // maakt een circel om de vogel heen van welke objecten force moeten krijgen


            if (Input.GetKeyDown(Constante.spacebar)&&canExplode == true && SpaceBarExplode) // als je op spatie klikt zet hij de playtimer op false zodat hij meteen explodeert
            {
            playTimer = false;
            StartCoroutine(ExplosionTimer());

            }
    }

    private void OnCollisionEnter2D(Collision2D collision) // als hij iets raakt staat de playtimer nog steeds op true zodat hij gaat wachten tot de audio klaar is en explodeert dan
    {

        if (collision.gameObject.layer == 8 && startTimer == true || collision.gameObject.layer == 9 && startTimer == true)
        {

            StartCoroutine(ExplosionTimer());

        }
    }

    private IEnumerator ExplosionTimer() // hier vind het kijken of hij mag exploderen plaats
    {

        if (playTimer == true) // als playtimer true is gaat hij audio spelen en explodeert daar na
        {
            startTimer = false; // als startTimer false is kan hij niet meer de IEnum kan aan roepen om iets te laten exploderen
            SpaceBarExplode = false;
            explosieAudio.clip = explosieTimer;
            explosieAudio.Play();
            yield return new WaitForSeconds(explosieAudio.clip.length);

            playTimer = false;

        }
        else
        {
            yield return new WaitForSeconds(0);
        }



        foreach (Collider2D hit in colliders) // hier zorgt hij er voor dat hij een force aan alle objecten geeft die in de overlap shere zitten
        {
            rb = hit.GetComponent<Rigidbody2D>();

            AddExplosionForce(rb, power, transform.position, radius);
        }
        canExplode = false;
        particleHandler.GetComponent<particleSystemPlayScript>().playParticle();

        onDestroy();
    }

    void AddExplosionForce(Rigidbody2D rb,float explosionForce, Vector2 explodingPosition, float radius, float upwardsModifier = 0.0f, ForceMode2D mode = ForceMode2D.Impulse)
    {

        if (canExplode == true)
        {

            Vector2 explodingDirection = rb.position - explodingPosition;
            float explodingDistance = explodingDirection.magnitude;
            if (rb.GetComponentInParent<Damage>() != null)
            {
                Damage block = rb.GetComponentInParent<Damage>();

                if (explodingDistance < radius / 2)
                {
                    block.setObjectHealt(block.maxhealt);
                }
                else
                {
                    if (explodingDistance > radius / 2 && explodingDistance < (radius / 4) * 3)
                    {
                        block.setObjectHealt((block.maxhealt / 3) * 2);
                    }
                    if (explodingDistance > (radius / 4) * 3 && explodingDistance < radius)
                    {
                        block.setObjectHealt((block.maxhealt / 3) * 1);
                    }

                }
                if (upwardsModifier == 0)
                {
                    explodingDirection /= explodingDistance;

                }
                else
                {
                    explodingDirection.Normalize();
                }
                rb.AddForce(Mathf.Lerp(0, explosionForce, (radius / explodingDistance)) * explodingDirection, mode);
            }

            explosieAudio.Play();
            if (upwardsModifier == 0)
            {
                explodingDirection /= explodingDistance;

            }
            else
            {
                explodingDirection.Normalize();
            }
            rb.AddForce(Mathf.Lerp(0, explosionForce, (radius / explodingDistance)) * explodingDirection, mode);            
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
