using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : BirdClass
{
    [SerializeField] AudioSource vogelAudio;
    [SerializeField] private AudioClip vogelLanceer;
    [SerializeField] private AudioClip slingshotPull;
    [SerializeField] private LineRenderer[] lines;
    [SerializeField] private bool isPressed;

    private CameraScript cameraScript;
    private RopeScript ropes;
    private float releaseDelay;
    private float maxDragDistance = 2f;
    public bool shot = false;

    
    [SerializeField] private SpringJoint2D sj;
    [SerializeField] private Rigidbody2D slingRb;
    [SerializeField]  private FollowBirds followBirds;
 

    

    private void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
        sj = GetComponent<SpringJoint2D>();
        sj.connectedBody = GameObject.Find("middelpunt").GetComponent<Rigidbody2D>();
        ropes = GameObject.Find("Catapult").GetComponent<RopeScript>();

        slingRb = sj.connectedBody;
    }

    private void Start()
    {
        vogelAudio.clip = slingshotPull;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        releaseDelay = 1 / (sj.frequency * 4);
        isPressed = false;
    }

    void Update()
    {
        if (isPressed)
        {
            DragBall();
        }
        if(shot)
        {
            ropes.setlinePostions(gameObject.transform.position);  
        }


        if(gameObject.transform.position.y <= -20f)
        {
            Destroy(this.gameObject);
        }
        
    }

    private void DragBall()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float distance = Vector2.Distance(mousePosition, slingRb.position);

        if (distance > maxDragDistance)
        {
            Vector2 direction = (mousePosition - slingRb.position).normalized;
            rb.position = slingRb.position + direction * maxDragDistance;
        }
        else
        {
            rb.position = mousePosition;
        }

        ropes.DrawLines();
    }

    private void OnMouseDown()
    {
        vogelAudio.Play();
        rb.constraints = RigidbodyConstraints2D.None;
        isPressed = true;
        rb.isKinematic = true;
        
    }

    private void OnMouseUp()
    {
        vogelAudio.clip = vogelLanceer;
        vogelAudio.Play();
        if (followBirds.followBird == 0)
        {
            followBirds.unevenBirds.Play();
        }
        if (followBirds.followBird == 1)
        {
            followBirds.evenBirds.Play();
        }
        isPressed = false;
        StartCoroutine(Release());
        rb.isKinematic = false;
        shot = true;


    }

    private IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseDelay);
        sj.enabled = false;
        shot = false;
    }
}
