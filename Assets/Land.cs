using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Land : MonoBehaviour
{
	public float balanceAngle = 10.0f;
	Rigidbody2D physics;
	Vector2 previousUp;
	Vector2 previousPos;
	float previousRot;

	void Awake()
	{
		physics = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
		previousUp = transform.up;
		previousPos = transform.position;
		previousRot = transform.rotation.eulerAngles.z;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		float angle = Vector2.Angle(previousUp, collision.transform.up);
		if (physics.isKinematic)
		{
			Debug.Log("Ignore");
		}
		else if (angle < balanceAngle)
		{
			Debug.Log("Land");
			physics.bodyType = RigidbodyType2D.Kinematic;
			physics.velocity = Vector2.zero;
			physics.angularVelocity = 0.0f;
			transform.position = previousPos;
			transform.rotation = Quaternion.Euler(0.0f, 0.0f, previousRot);
		}
		else
		{
			Debug.LogFormat("Bounce because angle is {0}", angle);
		}
	}
}
