using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private GameObject player;
    private Enemy_Movement enemyMove;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        enemyMove = GetComponent<Enemy_Movement>();
    }

	private void FixedUpdate()
	{
        enemyMove.Enemy_Move(moveSpeed);
	}
}
