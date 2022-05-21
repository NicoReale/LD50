using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireParticleController
{
    ParticleSystem glowParticles;
    ParticleSystem fireParticles;
    ParticleSystem.EmissionModule emissionModule;
    ParticleSystem.LightsModule fireLightsModule;

    public FireParticleController(ParticleSystem glowSystem, ParticleSystem fireSystem)
    {
        glowParticles = glowSystem;
        emissionModule = glowParticles.emission;
        fireParticles = fireSystem;
        fireLightsModule = fireSystem.lights;
    }

    public void GlowIntesity(float lightValue, float intensity)
    {
        emissionModule.rateOverTime = lightValue * intensity;
    }

    public void FireIntensity(float lightValue, float intensity)
    {
        fireLightsModule.intensityMultiplier = lightValue * intensity;
        fireParticles.transform.localScale = new Vector3(fireParticles.transform.localScale.x, lightValue, fireParticles.transform.localScale.z);
    }
}
