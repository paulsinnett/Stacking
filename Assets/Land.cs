using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : MonoBehaviour
{
	public float balanceAngle = 10.0f;
	Rigidbody2D physics;

	void Awake()
	{
		physics = GetComponent<Rigidbody2D>();
	}
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (Vector2.Angle(transform.up, collision.transform.up) < balanceAngle)
		{
			Debug.Log("Land");
			physics.velocity = Vector2.zero;
			physics.angularVelocity = 0.0f;
			physics.simulated = false;
		}
		else
		{
			Debug.Log("Bounce");
		}
	}
}
