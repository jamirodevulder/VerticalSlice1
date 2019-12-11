using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puntenVisual : MonoBehaviour
{
    private TextMesh thisObject;
    private int length = 25;
    private bool active = true;
    private int speed = 3;
    // Start is called before the first frame update
    void Start()
    {
        if (active == true)
        {
            active = false;
            thisObject = GetComponent<TextMesh>();
            StartCoroutine(puntenVisuals());
        }
    }
    private IEnumerator puntenVisuals()
    {
        
        if(int.Parse(thisObject.text) == 5000)
        {
            length = 30;
            speed = 4;
        }
        while(thisObject.fontSize < length)
        {
            thisObject.fontSize += 1;
            yield return new WaitForSeconds(0.05f);
        }
        while (thisObject.fontSize > 0)
        {
            thisObject.fontSize -= speed;
            yield return new WaitForSeconds(0.05f);
        }

        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
