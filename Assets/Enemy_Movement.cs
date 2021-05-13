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

    public void Enemy_Move(float moveSpeed)
	{
        // get difference, normalize it
        // apply to velocity

        // round the direction to -1, 0, 1
        // and set the values accordingly in anim
        // flip the sprites accordingly too!
	}
}
