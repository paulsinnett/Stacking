using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
	public Transform end;
	float a;
	float b;
	float c;

	void Update()
	{
		Vector2 start = transform.position;
		Vector2 end = this.end.position;

		Debug.DrawLine(start, end);
		a = end.y - start.y;
		b = start.x - end.x;
		c = a * start.x + b * start.y;
	}

	static public bool Intersect(Line a, Line b, out Vector2 c)
	{
		bool parallel = false;
		float det = a.a * b.b - b.a * a.b;
		if (Mathf.Abs(det) <= Mathf.Epsilon)
		{
			parallel = true;
			c = Vector2.zero;
		}
		else
		{
			c.x = (b.b*a.c - a.b*b.c) / det;
			c.y = (a.a*b.c - b.a*a.c) / det;
		}
		return !parallel;
	}
}
