using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : BirdClass
{
    [SerializeField] private LineRenderer[] lines;
    [SerializeField] private bool isPressed;

    private CameraScript cameraScript;
    private RopeScript ropes;
    private float releaseDelay;
    private float maxDragDistance = 2f;
    public bool shot = false;

    [SerializeField] private Sprite[] stars;
    [SerializeField] private SpringJoint2D sj;
    [SerializeField] private Rigidbody2D slingRb;
    [SerializeField] BirdEggScript kip;
    [SerializeField] ExplosionForce bom;




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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8 || collision.gameObject.layer == 9)
        {


            rb.constraints = RigidbodyConstraints2D.None;
        }
    }
    private void OnMouseDown()
    {

        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        isPressed = true;
        rb.isKinematic = true;
        
    }

    private void OnMouseUp()
    {
        isPressed = false;
        StartCoroutine(Release());
        rb.isKinematic = false;
        shot = true;
        if(kip != null)
        {
            kip.abillity = true;
        }
        else
        {
            bom.abillity = true;
        }

    }

    private IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseDelay);
        sj.enabled = false;
        shot = false;

        





    }
}
