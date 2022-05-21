using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text Wood;
    public PlayerModel player;

    // Update is called once per frame
    void Update()
    {
        Wood.text = "Wood : " + player.inventory.wood;
    }
}
