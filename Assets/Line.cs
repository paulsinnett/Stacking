using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
	public Transform end;

	void Update()
	{
		Vector2 start = transform.position;
		Vector2 end = this.end.position;

		Debug.DrawLine(start, end);
	}

	static float CrossProduct(Vector2 a, Vector2 b)
	{
		return a.x * b.y - b.x * a.y;
	}

	// returns true if the given line segment crosses this line
	// and sets t to the distance along the line starting at the
	// line start and scaled by the line length so:
	// t < 0 = line segment crosses before the start point
	// t = 0.5 = line segment crosses at the half way point
	// t > 1 = line segment crosses after the end point
	public bool Intersect(Line line, out float t)
	{
		Vector2 a = end.transform.position - transform.position;
		Vector2 b = line.end.transform.position - line.transform.position;
		Vector2 c = transform.position - line.transform.position;

		float d = CrossProduct(a, b);
		if (Mathf.Abs(d) <= Mathf.Epsilon)
		{
			t = 0.0f;
			return false;
		}

		float s = CrossProduct(a, c) / d;
		if (s < 0.0f || s > 1.0f)
		{
			t = 0.0f;
			return false;
		}

		t = CrossProduct(b, c) / d;
		return true;
	}
}
