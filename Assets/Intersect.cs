using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intersect : MonoBehaviour
{
	public Line motion;
	public Line head;

	void Update()
	{
		float t;
		if (head.Intersect(motion, out t))
		{
			Vector2 start = head.transform.position;
			Vector2 direction = (Vector2)head.end.transform.position - start;
			transform.position = start + t * direction;
		}
	}
}
