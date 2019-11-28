using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdClass : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSprite(Sprite ImageToChangeTo)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = ImageToChangeTo;
    }


    public void checkForDelete()
    {
        
    }
    public void onDestroy()
    {
        Destroy(gameObject);
    }


}
