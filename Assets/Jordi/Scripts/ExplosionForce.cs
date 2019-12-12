using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionForce : BirdClass
{

    [SerializeField] private float radius; // zorgt voor radius waar hij objecten aantast
    [SerializeField] private float power; // zorgt voor explosie power
    [SerializeField] private GameObject Cloud;
    [SerializeField] private LayerMask obstacleLayer; // layer van obstacels zoals dozen
    [SerializeField] private LayerMask groundLayer; // layer van de vloer
    [SerializeField] private AudioSource explosieAudio; // audio die de explosie af speelt
    [SerializeField] private AudioClip explosie; // de explosie geluid
    [SerializeField] private AudioClip explosieTimer; // het aftikkende geluid
    [SerializeField] private bool canExplode = true; // kijk of hij objecten nog aangetast kunnen worden
    [SerializeField] private bool playTimer = true; // kijkt of hij klaar is met audio spelen
    [SerializeField] private bool startTimer = true; // kijkt of hij de audio mag spelen of gelijk moet exploderen
    [SerializeField] private Animator boom;
    [SerializeField] private AnimationClip boomtime;
    [SerializeField] private GameObject animObj;
    [SerializeField] private particleSystemPlayScript AnimPlay;
    public bool abillity = false;
    private bool wolk = true;
    private bool SpaceBarExplode = true;
    [SerializeField] FollowBirds followBirds;
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


            if (Input.GetKeyDown(Constante.spacebar)&&canExplode == true  && abillity) // als je op spatie klikt zet hij de playtimer op false zodat hij meteen explodeert
            {
            playTimer = false;
            if (followBirds.followBird == 0)
            {
                Destroy(GameObject.Find("Cloud(Clone)"));
                if (wolk)
                {
                    Cloud = Instantiate(Cloud, this.transform.position, this.transform.rotation);
                }
                followBirds.evenBirds.Clear();
                followBirds.unevenBirds.Pause();
            }
            if (followBirds.followBird == 1)
            {
                Destroy(GameObject.Find("Cloud(Clone)"));
                if (wolk)
                {
                    Cloud = Instantiate(Cloud, this.transform.position, this.transform.rotation);
                }
                followBirds.unevenBirds.Clear();
                followBirds.evenBirds.Pause();
            }
            StartCoroutine(ExplosionTimer());

            }
    }

    private void OnCollisionEnter2D(Collision2D collision) // als hij iets raakt staat de playtimer nog steeds op true zodat hij gaat wachten tot de audio klaar is en explodeert dan
    {

        if (collision.gameObject.layer == 8 && startTimer == true || collision.gameObject.layer == 9 && startTimer == true)
        {
            wolk = false;
            StartCoroutine(ExplosionTimer());

        }
    }

    private IEnumerator ExplosionTimer() // hier vind het kijken of hij mag exploderen plaats
    {

        if (playTimer == true) // als playtimer true is gaat hij audio spelen en explodeert daar na
        {
            if (followBirds.followBird == 0)
            {
                Destroy(GameObject.Find("Cloud(Clone)"));
                followBirds.evenBirds.Clear();
                followBirds.unevenBirds.Pause();


            }
            if (followBirds.followBird == 1)
            {
                Destroy(GameObject.Find("Cloud(Clone)"));
                followBirds.unevenBirds.Clear();
                followBirds.evenBirds.Pause();
            }
            startTimer = false; // als startTimer false is kan hij niet meer de IEnum kan aan roepen om iets te laten exploderen

            boom.SetTrigger("explode");
            yield return new WaitForSeconds(boom.GetCurrentAnimatorStateInfo(0).length);

            playTimer = false;

        }
        else
        {
            yield return new WaitForSeconds(0);
        }



        foreach (Collider2D hit in colliders) // hier zorgt hij er voor dat hij een force aan alle objecten geeft die in de overlap shere zitten
        {
            if (hit != null)
            {
                rb = hit.GetComponent<Rigidbody2D>();

                AddExplosionForce(rb, power, transform.position, radius);
            }
        }
        canExplode = false;

        AnimPlay.playParticle("explode");
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

                if (explodingDistance < radius / 1.5)
                {
                    block.setObjectHealt(block.maxhealt);
                }
                else
                {
                    if (explodingDistance > radius / 3 && explodingDistance < radius)
                    {
                        block.setObjectHealt((block.maxhealt / 3) * 2);
                    }
                    if (explodingDistance > (radius / 4) * 3 && explodingDistance < radius)
                    {
                        block.setObjectHealt((block.maxhealt / 2) * 1);
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
