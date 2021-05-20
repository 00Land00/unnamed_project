using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testThrow3 : MonoBehaviour
{
	private const float GRAVITY = 9.81f;

	[SerializeField] private GameObject target;
	[SerializeField] private GameObject spriteChild;
	//[SerializeField] private float speed;


	private float verticalVel;
	private Rigidbody2D rb2d;
	private Player_Actions pa;

	private bool isFired = false;
	[SerializeField] private float time;

	private void Awake()
	{
		pa = new Player_Actions();
		pa.Player.Fire.performed += _ => Fire();

		rb2d = GetComponent<Rigidbody2D>();
	}

	private void OnEnable()
	{
		pa.Enable();
		pa.Player.Fire.performed += _ => Fire();
	}

	private void OnDisable()
	{
		pa.Disable();
		pa.Player.Fire.performed -= _ => Fire();
	}

	private void Update()
	{
		if(!isFired) { return; }
		time -= Time.deltaTime;
		if (time > 0)
		{
			UpdateSprite();
		}
	}

	private void FixedUpdate()
	{
		if(!isFired) { return; }

		if (time <= 0)
		{
			rb2d.velocity = Vector2.zero;
		}
	}

	private void UpdateSprite()
	{
		verticalVel += (GRAVITY) * Time.deltaTime * -1;
		spriteChild.transform.position += new Vector3(0, verticalVel, 0) * Time.deltaTime;
	}
	
	private void Fire()
	{
		Vector2 diff = target.transform.position - transform.position;
		//time = diff.magnitude / speed;
		//rb2d.velocity = diff.normalized * speed;
		rb2d.velocity = diff / time;
		verticalVel = GRAVITY * time / 2;

		isFired = true;
	}
}
