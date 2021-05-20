using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player_Data", menuName = "Player_Data")]
public class Player_Data : ScriptableObject
{
	[HideInInspector]
	public float GRAVITY = 9.81f;

	[Header("Player")]
	public float moveSpeed;

	[Header("Projectile")]
	public GameObject projectile;
	public float projectileTime;
	public float aimSpeed;
}
