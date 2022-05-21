using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour, IResource
{
    int woodToGive = 5;
    int totalWood = 10000;
    int id = 0;

    public void Interact()
    {
        totalWood -= woodToGive;
    }

    public int ReturnResource()
    {
        return woodToGive;
    }

    public int ID()
    {
        return id;
    }

    public void UpgradeResource()
    {
        woodToGive += 1;
    }
}
