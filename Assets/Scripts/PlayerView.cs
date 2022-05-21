using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    public Animator _anim;
    public SpriteRenderer _spriteRenderer;
    public Text Wood;
    public Text Stone;
    public PlayerModel player;


    public void Update()
    {
        Wood.text = "Wood : " + player.inventory.wood;
        Stone.text = "Stone : " + player.inventory.stone;
    }
    public void ViewRotation(float xDir)
    {
        if (xDir < 0) _spriteRenderer.flipX = true;
        else if (xDir > 0) _spriteRenderer.flipX = false;
    }
    public void OnPlayerMove(float dir)
    {
        _anim.SetInteger("direction", Mathf.Abs(Mathf.RoundToInt(dir)));
    }

    public void OnPickUp()
    {
        _anim.SetTrigger("pickup");
    }
    public void OnUse()
    {
        _anim.SetTrigger("using");
    }
}
