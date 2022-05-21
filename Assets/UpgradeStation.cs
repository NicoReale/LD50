using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UpgradeStation : MonoBehaviour, IConsumator
{
    int id = 1;

    float resource = 0;
    float maxResource = 100;
    int consumeAmount = 100;

    public Tree tree;

    public Image progress;

    public int ID()
    {
        return id;
    }

    public int MaxItemUsage()
    {
        return Mathf.RoundToInt(maxResource - resource);
    }

    public void Use(int received)
    {
        resource += received;
    }

    // Update is called once per frame
    void Update()
    {
        if(resource >= maxResource)
        {
            tree.UpgradeResource();
            resource = 0;
        }

        progress.fillAmount = resource / maxResource;
    }
}
