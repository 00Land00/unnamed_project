using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
	[SerializeField] private GameObject playerCursor;
	[SerializeField] private GameObject projectileStart;
	[SerializeField] private Player_Data playerData;

	private Player_Movement playerMove;
	private Player_Actions playerActions;

	private void Awake()
	{
		playerActions = new Player_Actions();
		playerActions.Player.Fire.performed += _ => Fire();

		playerMove = GetComponent<Player_Movement>();
	}

	private void OnEnable()
	{
		playerActions.Enable();
		playerActions.Player.Fire.performed += _ => Fire();
	}

	private void OnDisable()
	{
		playerActions.Disable();
		playerActions.Player.Fire.performed -= _ => Fire();
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
		playerMove.Move_Player(dir, playerData.moveSpeed);
	}

	private void Aim()
	{
		Vector2 dir = playerActions.Player.Aim.ReadValue<Vector2>();
		float speedFactor = playerData.aimSpeed * Time.deltaTime;
		playerCursor.transform.position = playerCursor.transform.position + new Vector3(dir.x * speedFactor, dir.y * speedFactor, 0);
	}

	private void Fire()
	{
		Player_Projectile projectile = Instantiate(playerData.projectile, projectileStart.transform.position, Quaternion.identity).GetComponent<Player_Projectile>();
		projectile.InitializeProjectile(playerData, playerCursor.transform.position);
		projectile.Fire();
		
	}

	public Player_Data GetPlayerData() { return playerData; }
}
