using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IResource
{
    public int ID();
    public void Interact();
    public int ReturnResource();

    public void UpgradeResource();
}
