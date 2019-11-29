using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eggExplodeScript : MonoBehaviour
{
    [SerializeField] private float radius = 5.0F; // zorgt voor radius waar hij objecten aantast
    [SerializeField] private float power = 10.0F; // zorgt voor explosie power
    [SerializeField] private AudioSource explosieAudio; // audio die de explosie af speelt
    [SerializeField] private bool canExplode = true; // kijk of hij objecten nog aangetast kunnen worden
    [SerializeField] private LayerMask obstacleLayer;
    Vector2 explosionPos;
    Collider2D[] colliders;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 explosionPos = transform.position;  // zorgt er voor dat hij weet van waar hij de explosie moet schieten
        colliders = Physics2D.OverlapCircleAll(explosionPos, radius, obstacleLayer); // maakt een circel om de vogel heen van welke objecten force moeten krijgen
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += Vector3.down;
    }


    private void OnCollisionEnter2D(Collision2D collision) // als hij iets raakt staat de playtimer nog steeds op true zodat hij gaat wachten tot de audio klaar is en explodeert dan
    {

        if (collision.gameObject.layer == 8 || collision.gameObject.layer == 9)
        {

            explode();

        }
    }


    private void explode()
    {
        foreach (Collider2D hit in colliders) // hier zorgt hij er voor dat hij een force aan alle objecten geeft die in de overlap shere zitten
        {
            rb = hit.GetComponent<Rigidbody2D>();
            AddExplosionForce(rb, power, transform.position, radius);
        }
        Destroy(this.gameObject);
    }


    void AddExplosionForce(Rigidbody2D rb, float explosionForce, Vector2 explodingPosition, float radius, float upwardsModifier = 0.0f, ForceMode2D mode = ForceMode2D.Impulse)
    {

        if (canExplode == true)
        {

            Vector2 explodingDirection = rb.position - explodingPosition;
            float explodingDistance = explodingDirection.magnitude;


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
