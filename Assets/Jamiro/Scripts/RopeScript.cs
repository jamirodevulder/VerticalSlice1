using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeScript : MonoBehaviour
{
    [SerializeField] GameObject firstLine;
    [SerializeField] GameObject secondLine;
    
    public GameObject[] birds;


    private LineRenderer line1;
    private LineRenderer line2;
    private Vector2 middleRange;
    

    // Start is called before the first frame update
    void Start()
    {
        line1 = firstLine.GetComponent<LineRenderer>();
        line2 = secondLine.GetComponent<LineRenderer>();
        middleRange = new Vector2(GameObject.Find("middelpunt").transform.position.x, GameObject.Find("middelpunt").transform.position.y);
        setlinePostions(middleRange);
    }





    void Update()
    {
        
    }
    public void DrawLines()
    {
            Vector2 mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float distance = Vector2.Distance(mouseposition, middleRange);

            if (distance > 2)
            {
                var direction = (mouseposition - middleRange).normalized;
                var maxPosition = middleRange + direction * 2f;
                setlinePostions(maxPosition);
            }
            else
            {
                setlinePostions(mouseposition);
            }
    }

    public void setlinePostions(Vector3 positionForLines)
    {
        positionForLines.z = -3f;
        line1.SetPosition(0, positionForLines);
        positionForLines.z = -6f;
        line2.SetPosition(0, positionForLines);
    }
    public void returnLines()
    {
        setlinePostions(middleRange);
        
    }

    public void newBird(int birdIndex)
    {


        
        birds[birdIndex].transform.position = new Vector3(middleRange.x, middleRange.y, -5f);
        birds[birdIndex].GetComponentInChildren<bird>().enabled = true;
        birds[birdIndex].GetComponentInChildren<SpringJoint2D>().enabled = true;
        birds[birdIndex].GetComponentInChildren<PolygonCollider2D>().enabled = true;
        birds[birdIndex].GetComponentInChildren<Rigidbody2D>().isKinematic = false;
        birds[birdIndex].GetComponentInChildren<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        birds[birdIndex].GetComponentInChildren<SpringJoint2D>().connectedBody = GameObject.Find("middelpunt").GetComponent<Rigidbody2D>();

        if (birds[birdIndex].GetComponentInChildren<ExplosionForce>() != null)
        {
            birds[birdIndex].GetComponentInChildren<ExplosionForce>().enabled = true;
        }
        else
        {

            birds[birdIndex].GetComponentInChildren<BirdEggScript>().enabled = true;
        }



    }

}
