using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeScript : MonoBehaviour
{
    [SerializeField]
    GameObject firstLine;
    private LineRenderer line1;
    [SerializeField]
    GameObject secondLine;
    private LineRenderer line2;
    private Vector3 middleRange;
    [SerializeField]
    private GameObject[] birds = new GameObject[3];
    private int birdCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        line1 = firstLine.GetComponent<LineRenderer>();
        line2 = secondLine.GetComponent<LineRenderer>();
        middleRange = new Vector3((firstLine.transform.position.x + secondLine.transform.position.x) / 2,(firstLine.transform.position.y + secondLine.transform.position.y) / 2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        DrawLines();
        
    }
    private void DrawLines()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mouseposition = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 1.1f);
            mouseposition.z = 0;
            if (Vector3.Distance(mouseposition, middleRange) > 1.5f)
            {
                var maxPosition = (mouseposition - middleRange).normalized * 1.5f + middleRange;
                maxPosition.z = 1.1f;
                setlinePostions(maxPosition);
                maxPosition.z = 1f;
                setBirdPosition(maxPosition);
            }
            else
            {
                setlinePostions(mouseposition);
                setBirdPosition(mouseposition);
            }

           

        }
    }

    private void setlinePostions(Vector3 positionForLines)
    {
        positionForLines.z = 1.1f;
        line1.SetPosition(0, positionForLines);
        positionForLines.z = 0.5f;
        line2.SetPosition(0, positionForLines);
    }
    private void setBirdPosition(Vector3 positionForBirds)
    {
        positionForBirds.z = 1;
        birds[birdCount].transform.position = positionForBirds;
    }
}
