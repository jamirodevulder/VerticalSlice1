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
    private Vector2 middleRange;
    private int birdIndex;

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

        if(birds[birdIndex] == null && birdIndex < birds.Length - 1)
        {
            birdIndex++;
            newBird();
        }







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
        positionForLines.z = 1.1f;
        line1.SetPosition(0, positionForLines);
        positionForLines.z = 0.5f;
        line2.SetPosition(0, positionForLines);
    }
    public void returnLines()
    {
        setlinePostions(middleRange);
    }

    private void newBird()
    {
        birds[birdIndex].transform.position = new Vector3(middleRange.x, middleRange.y, 0f);

        birds[birdIndex].GetComponentInChildren<bird>().enabled = true;
        birds[birdIndex].GetComponentInChildren<SpringJoint2D>().enabled = true;
        birds[birdIndex].GetComponentInChildren<SpringJoint2D>().connectedBody = GameObject.Find("middelpunt").GetComponent<Rigidbody2D>();
        birds[birdIndex].GetComponentInChildren<ExplosionForce>().enabled = true;

    }

}
