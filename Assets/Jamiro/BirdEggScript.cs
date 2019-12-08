using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdEggScript : BirdClass
{
    [SerializeField] GameObject egg;
    private GameManager gameManager;
    private bool eggGemaakt = true;
    private CameraScript cameraScript;
    // Start is called before the first frame update
    void Start()
    {
        
        //  gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && eggGemaakt)
        {
            eggGemaakt = false;
            Instantiate(egg, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), Quaternion.identity);
            
        }
   
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8 || collision.gameObject.layer == 9)
        {
            eggGemaakt = false;
            StartCoroutine(DestroyTimer());
            

        }
    }

    private IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(3);
        //gameManager.increaseIndex();
        yield return new WaitForSeconds(3);
        onDestroy();
    }
}
