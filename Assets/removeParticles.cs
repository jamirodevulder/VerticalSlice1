using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeParticles : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void removeParticleSystem(ParticleSystem time)
    {
        StartCoroutine(remove(time));
    }

    public IEnumerator remove(ParticleSystem time)
    {
        yield return new WaitForSeconds(time.main.duration);
        Destroy(this.gameObject);
    }
}
