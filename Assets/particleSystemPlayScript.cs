using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleSystemPlayScript : MonoBehaviour
{
    [SerializeField] ParticleSystem boomparticle;
    [SerializeField] AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        
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
        boomparticle.Play();
        audioSource.Play();
        yield return new WaitForSeconds(boomparticle.main.duration);
        Destroy(gameObject);
    }
}
