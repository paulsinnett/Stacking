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

	// returns true if the given line segment crosses this line
	// and sets t to the distance along the line starting at the
	// line start and scaled by the line length so:
	// t < 0 = line segment crosses before the start point
	// t = 0.5 = line segment crosses at the half way point
	// t > 1 = line segment crosses after the end point
	public bool Intersect(Line line, out float t)
	{
		Vector2 a = transform.position;
		Vector2 b = end.transform.position;
		Vector2 c = line.transform.position;
		Vector2 d = line.end.transform.position;

		float tNumerator = (c.y - d.y) * (a.x - c.x) + (d.x - c.x) * (a.y - c.y);
		float tDenominator = (d.x - c.x) * (a.y - b.y) - (a.x - b.x) * (d.y - c.y);

		float sNumerator = (a.y - b.y) * (a.x - c.x) + (b.x - a.x) * (a.y - c.y);
		float sDenominator = (d.x - c.x) * (a.y - b.y) - (a.x - b.x) * (d.y - c.y);

		if (Mathf.Abs(sDenominator) <= Mathf.Epsilon || Mathf.Abs(tDenominator) <= Mathf.Epsilon)
		{
			t = 0.0f;
			// parallel
			return false;
		}

		float s = sNumerator / sDenominator;
		if (s < 0.0f || s > 1.0f)
		{
			// input line segment doesn't reach my line
			t = 0.0f;
			return false;
		}

		t = tNumerator / tDenominator;
		return true;
	}
}
