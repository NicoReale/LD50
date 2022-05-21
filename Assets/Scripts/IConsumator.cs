using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IConsumator
{
    public int ID();
    public void Use(int received);

    public int MaxItemUsage();
}
