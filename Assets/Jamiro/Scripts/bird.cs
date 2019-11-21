using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : BirdClass
{
    [SerializeField] private LineRenderer[] lines;
    [SerializeField] private bool isPressed;

    private RopeScript ropes;
    private float releaseDelay;
    private float maxDragDistance = 2f;
    private bool shot = false;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpringJoint2D sj;
    [SerializeField] private Rigidbody2D slingRb;
    [SerializeField] private GameObject bird1;

    

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
        print("test");
        rb.constraints = RigidbodyConstraints2D.None;
        isPressed = true;
        rb.isKinematic = true;
        
    }

    private void OnMouseUp()
    {
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
