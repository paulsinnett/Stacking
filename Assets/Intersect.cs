using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intersect : MonoBehaviour
{
	public Line lineA;
	public Line lineB;

	void Update()
	{
		Vector2 intersect;
		if (Line.Intersect(lineA, lineB, out intersect))
		{
			transform.position = intersect;
		}
	}
}
