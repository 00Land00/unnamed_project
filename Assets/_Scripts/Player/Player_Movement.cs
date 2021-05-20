using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    private Player_Data playerData;
    private Rigidbody2D rb2d;
    private Animator anim;
    void Start()
    {
        playerData = GetComponent<Player>().GetPlayerData();
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private Vector2 newVel;
    public void Move_Player(Vector2 dir, float moveSpeed)
	{
        newVel = dir * moveSpeed;
        rb2d.velocity = newVel;

        anim.SetBool("isWalking", transform.hasChanged);
        if(transform.hasChanged)
		{
            transform.hasChanged = false;
		}

        FlipSprite();
	}

    private void FlipSprite()
	{
        bool hSpeed = Mathf.Abs(rb2d.velocity.x) > Mathf.Epsilon;
        // must be the Player_Sprite child
        if(hSpeed) { transform.GetChild(0).localScale = new Vector2(-1 * Mathf.Sign(rb2d.velocity.x), 1f); }
	}
}
