using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour, IResource
{

    int stoneToGive = 5;
    int totalStone = 10000;
    int id = 1;

    public int ID()
    {
        return id;
    }

    public void Interact()
    {
        totalStone -= stoneToGive;
    }

    public int ReturnResource()
    {
        return stoneToGive;
    }

    public void UpgradeResource()
    {
        stoneToGive += 1;
    }

}
