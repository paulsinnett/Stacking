using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
	public Behaviour jump;

	void Update()
	{
		if (!jump.enabled && Input.GetKeyDown(KeyCode.Space))
		{
			jump.enabled = true;
		}
	}
}
