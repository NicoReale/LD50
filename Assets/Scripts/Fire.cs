using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Fire : MonoBehaviour, IConsumator
{
    int id = 0;

    float fuel = 70;
    float maxFuel = 100;
    int consumeAmount = 100;

    public ParticleSystem GlowParticles;
    public ParticleSystem FireParticles;

    FireParticleController particleController;

    public Image healthBar;

    public void Use(int received)
    {
        fuel += received;
    }

    
    void Start()
    {
        particleController = new FireParticleController(GlowParticles, FireParticles);
    }

    // Update is called once per frame
    void Update()
    {
        fuel -= Time.deltaTime * 4f;
        if (fuel > maxFuel)
        {
            fuel = maxFuel;
        }
        if(fuel < 0)
        {
            fuel = 0;
        }
        float fuelPerc = fuel / maxFuel;
        particleController.GlowIntesity(fuelPerc, 5);
        particleController.FireIntensity(fuelPerc, 5);
        healthBar.fillAmount = fuelPerc;
    }

    public int ID()
    {
        return id;
    }

    public int MaxItemUsage()
    {
        return Mathf.RoundToInt(maxFuel - fuel);
    }
}
