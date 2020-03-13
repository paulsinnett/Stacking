using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class SmoothedLineRender : MonoBehaviour
{
	new Renderer renderer;
	Material line;
	public float width;
	[SerializeField] Transform start;
	[SerializeField] Transform end;

	void Awake()
	{
		renderer = GetComponent<Renderer>();
		line = renderer.material;
		renderer.material = line;
	}

	void Update()
	{
		Vector3 vector = end.position - start.position;
		if (vector.magnitude > 0.0f)
		{
			Vector3 middle = (start.position + end.position) * 0.5f;
			transform.position = middle;
			transform.localScale = new Vector3(vector.magnitude, width, 1.0f);
			transform.rotation = Quaternion.Euler(0.0f, 0.0f, Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg);
			float aspect = width / vector.magnitude;
			line.SetVector("_Edges", new Vector4(0.5f * aspect, 0.5f, 1.0f - 0.5f * aspect, 0.5f));
			renderer.enabled = true;
		}
		else
		{
			renderer.enabled = false;
		}
	}
}
