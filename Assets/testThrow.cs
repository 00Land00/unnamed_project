using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class testThrow : MonoBehaviour
{
	//[SerializeField] private GameObject target;
	//[SerializeField] private float vSpeed;
	//[SerializeField] private float moveSpeed;

	//[SerializeField] private GameObject spriteGO;
	//private Rigidbody2D rb2d;
	//   private Player_Actions pa;

	//private bool goTime;

	//private void Awake()
	//{
	//	pa = new Player_Actions();
	//	pa.Player.Fire.performed += _ => YeetSelf();
	//	rb2d = spriteGO.GetComponent<Rigidbody2D>();
	//}

	//private void OnEnable()
	//{
	//	pa.Enable();
	//	pa.Player.Fire.performed += _ => YeetSelf();
	//}

	//private void OnDisable()
	//{
	//	pa.Disable();
	//	pa.Player.Fire.performed += _ => YeetSelf();
	//}

	//// Start is called before the first frame update
	//private void Start()
	//   {
	//	rb2d.gravityScale = 0;
	//	goTime = false;
	//   }

	//private void Update()
	//{
	//	if(goTime)
	//	{
	//		//transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
	//	}
	////}

	//private void YeetSelf()
	//{
	//	Vector2 dir = (target.transform.position - transform.position).normalized;

	//	goTime = true;
	//	rb2d.gravityScale = 1;
	//	rb2d.velocity = new Vector2(0, vSpeed);
	//	GetComponent<Rigidbody2D>().velocity = dir * moveSpeed;
	//}

	[SerializeField] private Transform trnsObj;
	[SerializeField] private Transform trnsBody;
	[SerializeField] private Transform trnsShadow;

	[SerializeField] private float gravity = -10;
	[SerializeField] private Vector2 gVel;
	[SerializeField] private float vVel;

	[SerializeField] private bool isGrounded;

	private Player_Actions pa;

	private void Awake()
	{
		pa = new Player_Actions();
		pa.Player.Fire.performed += _ => Initialize();
	}

	private void OnEnable()
	{
		pa.Enable();
		pa.Player.Fire.performed += _ => Initialize();
	}

	private void OnDisable()
	{
		pa.Disable();
		pa.Player.Fire.performed -= _ => Initialize();
	}

	private void Start()
	{
		isGrounded = false;
	}

	public void Initialize()
	{
		isGrounded = true;
		Debug.Log("FIRED");
	}

	private void Update()
	{
		UpdatePosition();
	}

	private void UpdatePosition()
	{
		if(!isGrounded) { return; }
		vVel += gravity * Time.deltaTime;
		trnsBody.position += new Vector3(0, vVel, 0) * Time.deltaTime;

		trnsObj.position += (Vector3) (gVel * Time.deltaTime);
	}
}
