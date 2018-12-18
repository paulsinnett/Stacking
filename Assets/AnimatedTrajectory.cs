using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedTrajectory : MonoBehaviour
{
	public AnimationCurve timeCurve;
	float velocity = 12.0f;
	float angle = 75.0f;
	float time = 0.0f;
	float totalTime = 0.0f;
	Vector2 startPosition;
	static float g = 9.81f;
	
    //calculate height and distance of each vertex
    static Vector2 CalculateArcPoint(float time, float velocity, float angle)
    {
		Vector2 displacement = Vector2.zero;
        displacement.x = time * velocity * Mathf.Cos(angle * Mathf.Deg2Rad);
        displacement.y = time * velocity * Mathf.Sin(angle * Mathf.Deg2Rad) - 0.5f * g * time * time;
        return displacement;
    }

	static float TimeAtPeak(float velocity, float angle)
	{
		return (velocity * Mathf.Sin(angle * Mathf.Deg2Rad)) / g;
	}

	void OnEnable()
	{
		Debug.Log("Jump");
		startPosition = transform.position;
		totalTime = TimeAtPeak(velocity, angle) * 2.0f;
	}

	void Update()
	{
		time += Time.deltaTime;
		float animationTime = time; //timeCurve.Evaluate(time / totalTime) * totalTime;
		transform.position = startPosition + CalculateArcPoint(animationTime, velocity, angle);
	}
}
