using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testThrow2 : MonoBehaviour
{
	private const float GRAVITY = 9.81f;

    [SerializeField] private GameObject target;
    [SerializeField] private float initV;

	[SerializeField] private GameObject spriteChild;

	private Rigidbody2D rb2d;
	private bool fired = false;

	private Player_Actions pa;
	private void Awake()
	{
		pa = new Player_Actions();
		pa.Player.Fire.performed += _ => Fire();

		rb2d = GetComponent<Rigidbody2D>();
		rb2d.gravityScale = 0;
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

	private float vVel;
	private void Update()
	{
		float diff = (target.transform.position - transform.position).magnitude;
		if(diff < Mathf.Epsilon)
		{
			Destroy(gameObject);
		}

		if(fired)
		{
			vVel += -GRAVITY * Time.deltaTime;
			spriteChild.transform.position += new Vector3(0, vVel, 0) * Time.deltaTime;
		}
	}

	private void Fire()
	{
		//rb2d.gravityScale = 1;
		fired = true;
		Vector2 targetPos = target.transform.position;
		float x = targetPos.x - transform.position.x;
		float y = targetPos.y - transform.position.y;

		float theta = CalcTheta(x, y);
		//rb2d.velocity = new Vector2(initV * Mathf.Cos(theta), initV * Mathf.Sin(theta));
		vVel = initV * Mathf.Sin(theta);
		Debug.Log(theta * 180 / Mathf.PI);
	}

	private float CalcTheta(float x, float y)
	{
		float b = initV * x;
		float a = GRAVITY * x * x / -2;
		float temp = 4 * a;
		float fourAC = temp * (temp - 4 * y);

		float quadForm1 = -b + Mathf.Sqrt(b * b - fourAC);
		float quadForm2 = -b - Mathf.Sqrt(b * b - fourAC);
		quadForm1 /= 2 * a;
		quadForm2 /= 2 * a;

		quadForm1 = Mathf.Atan(quadForm1);
		quadForm2 = Mathf.Atan(quadForm2);
		return (quadForm1 > 0) ? quadForm1 : quadForm2;
	}
}
