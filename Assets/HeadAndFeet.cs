using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PolygonCollider2D))]
public class HeadAndFeet : MonoBehaviour
{
	Rigidbody2D physics;
	Vector2 [] head; // in local co-ordinates
	Vector2 [] feet;

	void Awake()
	{
		physics = GetComponent<Rigidbody2D>();
		PolygonCollider2D collider = physics.GetComponent<PolygonCollider2D>();
		Debug.Assert(collider.pathCount == 1);
		List<Vector2> path = new List<Vector2>(collider.GetPath(0));
		path.Sort((a, b) => a.y.CompareTo(b.y));
		feet = path.GetRange(0, 2).ToArray();
		head = path.GetRange(path.Count - 2, 2).ToArray();
	}

	void Update()
	{
		Debug.DrawLine(transform.TransformPoint(head[0]), transform.TransformPoint(head[1]), Color.red);
		Debug.DrawLine(transform.TransformPoint(feet[0]), transform.TransformPoint(feet[1]), Color.blue);
	}
}
