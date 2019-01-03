using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line
{
	Vector2 [] p = new Vector2[2];

	public Line(Vector2 start, Vector2 end)
	{
		Update(start, end);
	}

	public Line Transform(Transform transform)
	{
		return new Line(transform.TransformPoint(p[0]), transform.TransformPoint(p[1]));
	}

	public void DebugDraw()
	{
		Debug.DrawLine(p[0], p[1]);
	}

	public void Update(Vector2 start, Vector2 end)
	{
		p[0] = start;
		p[1] = end;
	}

	static float CrossProduct(Vector2 a, Vector2 b)
	{
		return a.x * b.y - a.y * b.x;
	}
	// returns true if the given line segment crosses my line
	// and sets t to the distance along my line starting p[0]
	// and scaled by my line length so:
	// t < 0 = line segment crosses before p[0]
	// t = 0.5 = line segment crosses half way
	// t > 1 = line segment crosses after p[1]
	public bool IntersectSegment(Line segment, out float t)
	{
		Vector2 a = p[1] - p[0];
		Vector2 b = segment.p[1] - segment.p[0];
		Vector2 c = p[0] - segment.p[0];

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

	public Vector2 GetPosition(float t)
	{
		return p[0] + (p[1] - p[0]) * t;
	}
}
