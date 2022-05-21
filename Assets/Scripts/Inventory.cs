using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Inventory
{
    public int wood;
    public int stone;


    public Inventory(int startingWood = 0, int startingStone = 0)
    {
        wood = startingWood;
        stone = startingStone;
    }

    public void AddResource(int amount, int id)
    {

        if (id == 0)
        {
            wood += amount;
        }
        else if (id == 1)
        {
            stone += amount;
        }
        else
        {
            Debug.LogWarning("Wrong item ID");
        }
    }

    public void RemoveResource(int amount, int id)
    {

        if (id == 0 && wood > 0)
        {
            wood -= amount;
        }
        else if (id == 1 && stone > 0)
        {
            stone -= amount;
        }
        else
        {
            Debug.LogWarning("Wrong item ID");
        }
    }


    public bool CheckResource(int id)
    {
        bool isAny = false;
        if(id == 0 && wood > 0)
        {
            isAny = true;
        }
        else if(id == 0 && wood == 0)
        {
            isAny = false;
        }
        if (id == 1 && stone > 0)
        {
            isAny = true;
        }
        else if(id == 1 && stone == 0)
        {
            isAny = false;
        }

        return isAny;
    }
}
