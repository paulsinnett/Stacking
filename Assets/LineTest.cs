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

	static float Determinant(Vector2 a, Vector2 b)
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
		Vector2 [] s = segment.p;
		Vector2 dp = p[1] - p[0];
		Vector2 ds = s[1] - s[0];
		Vector2 sp = p[0] - s[0];

		float d = Determinant(dp, ds);

		if (Mathf.Abs(d) <= Mathf.Epsilon || Mathf.Abs(d) <= Mathf.Epsilon)
		{
			t = 0.0f;
			// parallel
			return false;
		}

		float u = Determinant(dp, sp) / d;
		if (u < 0.0f || u > 1.0f)
		{
			// input line segment doesn't reach my line
			t = 0.0f;
			return false;
		}

		t = Determinant(ds, sp) / d;
		return true;
	}

	public Vector2 GetPosition(float t)
	{
		return p[0] + (p[1] - p[0]) * t;
	}
}

public class LineTest : MonoBehaviour
{
	public Transform end;
	public Line line;

	void Awake()
	{
		line = new Line(transform.position, end.transform.position);
	}

	void Update()
	{
		Vector2 start = transform.position;
		Vector2 end = this.end.position;
		line.Update(start, end);
		line.DebugDraw();
	}
}
