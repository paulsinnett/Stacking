using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
