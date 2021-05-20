using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Projectile : MonoBehaviour
{
	[SerializeField] private GameObject projectileSprite;

	private Vector2 targetPos;
	private Rigidbody2D rb2d;
	private Player_Data playerData;

	[SerializeField] private float verticalVel;
	private float time;

	private bool isFired = false;

	public void InitializeProjectile(Player_Data playerData, Vector2 targetPos)
	{
		this.playerData = playerData;
		this.targetPos = targetPos;

		rb2d = GetComponent<Rigidbody2D>();
		time = this.playerData.projectileTime;
	}

	private void Update()
	{
		if (!isFired) { return; }
		time -= Time.deltaTime;
		if (time > 0)
		{
			UpdateSprite();
		}
	}

	private void FixedUpdate()
	{
		if (!isFired) { return; }

		if (time <= 0)
		{
			Destroy(gameObject);
		}
	}

	private void UpdateSprite()
	{
		verticalVel += (playerData.GRAVITY) * Time.deltaTime * -1;
		projectileSprite.transform.position += new Vector3(0, verticalVel, 0) * Time.deltaTime;
	}

	public void Fire()
	{
		Vector2 diff = targetPos - (Vector2)transform.position;
		rb2d.velocity = diff / time;
		verticalVel = playerData.GRAVITY * time / 2;

		isFired = true;
	}
}
