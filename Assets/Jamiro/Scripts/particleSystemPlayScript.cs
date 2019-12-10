using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleSystemPlayScript : MonoBehaviour
{
    [SerializeField] private GameObject animObj;
    private Animator explodeAnim;

    // Start is called before the first frame update
    void Start()
    {
        explodeAnim = animObj.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playParticle()
    {
        StartCoroutine(startBoom());
    }


    private IEnumerator startBoom()
    {
        animObj.GetComponent<SpriteRenderer>().enabled = true;
        explodeAnim.SetTrigger("explode");
        yield return new WaitForSeconds(explodeAnim.GetCurrentAnimatorStateInfo(0).length / 2.4f);
        Destroy(gameObject);
    }
}
