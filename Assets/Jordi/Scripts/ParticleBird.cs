using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBird : MonoBehaviour
{
    [SerializeField] private GameObject bird;
    [SerializeField] private float particleSize = 0.1f;
    [SerializeField] private int sizeCounter;
    [SerializeField] private float emissionRate = 10;
    private ParticleSystem thisParticle;
    private ParticleSystem.MainModule thisPSMain;
    private ParticleSystem.EmissionModule thisPSEmission;
    

    private void Awake()
    {
        bird = this.gameObject;
        emissionRate = 10f;
        thisParticle = GetComponent<ParticleSystem>();
        thisPSMain = thisParticle.main;
        thisPSEmission = thisParticle.emission;
        StartCoroutine(EmitParitcle());
    }
    
    // Update is called once per frame
    void Update()
    {
        Debug.Log(thisPSEmission.rateOverTime);
        transform.position = bird.transform.position;
        //particle size
        
        thisPSMain.startSize = particleSize;

        //Emission Rate
        thisPSEmission.rateOverTime = emissionRate;
        
    }

    private IEnumerator EmitParitcle()
    {
        if (particleSize < 0.4f)
        {
            particleSize += 0.1f;
            yield return new WaitForSeconds(1 / emissionRate);
        }
        else
        {
            particleSize = 0.1f;
        }
        StartCoroutine(EmitParitcle());
    }
}
