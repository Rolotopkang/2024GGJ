using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_ResourceCollectc_Controller : MonoBehaviour
{
    private ParticleSystem ParticleSystem;

    private void Awake()
    {
        ParticleSystem = GetComponent<ParticleSystem>();
    }


    public void Init(int resourceCount , Material resourceMaterial)
    {
        var emission = ParticleSystem.emission;
        ParticleSystem.GetComponent<Renderer>().material = resourceMaterial;
        emission.rateOverTime = new ParticleSystem.MinMaxCurve(resourceCount);
        ParticleSystem.Play();
    }
}
