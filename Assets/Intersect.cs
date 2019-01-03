using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intersect : MonoBehaviour
{
	public LineTest motion;
	public LineTest head;

	void Update()
	{
		float t;
		if (head.line.IntersectSegment(motion.line, out t))
		{
			transform.position = head.line.GetPosition(t);
		}
		else
		{
			transform.position = motion.end.transform.position;
		}
	}
}
