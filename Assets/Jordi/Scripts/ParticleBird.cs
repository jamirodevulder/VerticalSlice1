using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBird : MonoBehaviour
{
    [SerializeField] private float particleSize = 0.1f;
    [SerializeField] private int sizeCounter;
    [SerializeField] private float emissionRate = 10;
    [SerializeField] private ParticleSystem thisParticle;
    private ParticleSystem.MainModule thisPSMain;
    private ParticleSystem.EmissionModule thisPSEmission;
    

    private void Awake()
    {
        emissionRate = 10f;
        thisParticle = GetComponent<ParticleSystem>();
        thisPSMain = thisParticle.main;
        thisPSEmission = thisParticle.emission;
        StartCoroutine(EmitParitcle());
    }
    
    // Update is called once per frame
    void Update()
    {

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
