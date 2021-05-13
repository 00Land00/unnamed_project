using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
	[SerializeField] private GameObject player_cursor;
	[SerializeField] private float moveSpeed;
	[SerializeField] private float aimSpeed;

	private Player_Movement playerMove;
	private Player_Actions playerActions;
	private void Awake()
	{
		playerActions = new Player_Actions();
		playerMove = GetComponent<Player_Movement>();
	}

	// ok things are starting to make sense and i think this is it!!
	private void OnEnable()
	{
		playerActions.Enable();
	}

	private void OnDisable()
	{
		playerActions.Disable();
	}

	void Start()
    {
        
    }

	private void Update()
	{
		Aim();
	}

	private void FixedUpdate()
	{
		Move();
	}

	private void Move()
	{
		Vector2 dir = playerActions.Player.Move.ReadValue<Vector2>();
		playerMove.Move_Player(dir, moveSpeed);
	}

	private void Aim()
	{
		Vector2 dir = playerActions.Player.Aim.ReadValue<Vector2>();
		float speedFactor = aimSpeed * Time.deltaTime;
		player_cursor.transform.position = player_cursor.transform.position + new Vector3(dir.x * speedFactor, dir.y * speedFactor, 0);
	}

	private void Fire()
	{

	}
}
