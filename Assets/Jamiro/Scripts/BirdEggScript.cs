using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdEggScript : BirdClass
{
    [SerializeField] GameObject egg;
    private GameManager gameManager;
    private bool eggGemaakt = true;
    private bool wait = false;
    public bool abillity = false;
    private CameraScript cameraScript;
    [SerializeField] private ParticleSystem[] systems;
    [SerializeField] private GameObject particleRemover;
    [SerializeField] private Sprite pushedEggOut;
    [SerializeField] FollowBirds followBirds;
    [SerializeField] private GameObject Cloud;
    private GameObject cloud;
    // Start is called before the first frame update
    void Start()
    {

        //  gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && eggGemaakt && abillity)
        {
            wait = true;
            eggGemaakt = false;
            if (followBirds.followBird == 0)
            {
                Destroy(GameObject.Find("Cloud(Clone)"));
                Cloud = Instantiate(Cloud, this.transform.position, this.transform.rotation);
                followBirds.evenBirds.Clear();
                followBirds.unevenBirds.Pause();
            }
            if (followBirds.followBird == 1)
            {
                Destroy(GameObject.Find("Cloud(Clone)"));
                Cloud = Instantiate(Cloud, this.transform.position, this.transform.rotation);
                followBirds.unevenBirds.Clear();
                followBirds.evenBirds.Pause();
            }
            Instantiate(egg, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), Quaternion.identity);
            if (gameObject.GetComponent<Rigidbody2D>().velocity.x > 0)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(1, 1, 0) * 10;
            }
            else
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(-1, 1, 0) * 10;
            }
            StartCoroutine(DestroyTimer());
            gameObject.GetComponent<SpriteRenderer>().sprite = pushedEggOut;
           
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8 || collision.gameObject.layer == 9)
        {
            wait = true;
            
            StartCoroutine(DestroyTimer());

            if (followBirds.followBird == 0 && eggGemaakt )
            {
                Destroy(GameObject.Find("Cloud(Clone)"));
                followBirds.evenBirds.Clear();
                followBirds.unevenBirds.Pause();
            }
            if (followBirds.followBird == 1 && eggGemaakt)
            {
                Destroy(GameObject.Find("Cloud(Clone)"));
                followBirds.unevenBirds.Clear();
                followBirds.evenBirds.Pause();
            }


            eggGemaakt = false;
        }
    }

    private IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(3);

        if (!wait)
        {
            yield return new WaitForSeconds(3);
        }
        systems[0].Play();
        particleRemover.GetComponent<removeParticles>().removeParticleSystem(systems[0]);
        onDestroy();
    }
}
