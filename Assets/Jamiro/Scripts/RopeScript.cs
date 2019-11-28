using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeScript : MonoBehaviour
{
    [SerializeField] GameObject firstLine;
    [SerializeField] GameObject secondLine;
 

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



}
