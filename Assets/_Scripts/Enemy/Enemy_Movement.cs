using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void Enemy_Move(GameObject player, float moveSpeed)
	{
        Vector2 dir = (player.transform.position - transform.position).normalized;
        rb2d.velocity = dir * moveSpeed;

        

        bool isMoving = Mathf.Abs(rb2d.velocity.magnitude) > Mathf.Epsilon;
        anim.SetBool("isMoving", isMoving);
        if(isMoving)
		{
            float velX = Mathf.Round(rb2d.velocity.normalized.x);
            float velY = Mathf.Round(rb2d.velocity.normalized.y);
            anim.SetFloat("x", velX);
            anim.SetFloat("y", velY);
        }
	}
}
