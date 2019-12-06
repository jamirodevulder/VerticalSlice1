using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeScript : MonoBehaviour
{
    [SerializeField] GameObject firstLine;
    [SerializeField] GameObject secondLine;
    [SerializeField] GameObject[] birds;


    private LineRenderer line1;
    private LineRenderer line2;
    private Vector3 middleRange;
    [SerializeField] private float range;
    

    // Start is called before the first frame update
    void Start()
    {
        line1 = firstLine.GetComponent<LineRenderer>();
        line2 = secondLine.GetComponent<LineRenderer>();
        middleRange = GameObject.Find("middelpunt").transform.position;
        
        setlinePostions(middleRange);
    }





    void Update()
    {
        
    }
    public void DrawLines()
    {
        Vector3 mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseposition.z = 1;

            float distance = Vector2.Distance(mouseposition, middleRange);

            if (distance > range)
            {
                var direction = (mouseposition - middleRange).normalized;
                var maxPosition = middleRange + direction * range;
                setlinePostions(maxPosition);
            }
            else
            {
                setlinePostions(mouseposition);
            }
    }

    public void setlinePostions(Vector3 positionForLines)
    {
        positionForLines.z = 1f;
        line1.SetPosition(0, positionForLines);
        positionForLines.z = 1f;
        line2.SetPosition(0, positionForLines);
    }
    public void returnLines()
    {
        setlinePostions(middleRange);
        
    }

    public void newBird(int birdIndex)
    {


        
        birds[birdIndex].transform.position = new Vector3(middleRange.x, middleRange.y, 0f);
        birds[birdIndex].GetComponentInChildren<bird>().enabled = true;
        birds[birdIndex].GetComponentInChildren<SpringJoint2D>().enabled = true;
        birds[birdIndex].GetComponentInChildren<SpringJoint2D>().connectedBody = GameObject.Find("middelpunt").GetComponent<Rigidbody2D>();
        birds[birdIndex].GetComponentInChildren<ExplosionForce>().enabled = true;




    }

}
