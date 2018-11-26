using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolicProjectile2D : MonoBehaviour {

	public float destTime = 2f;
	public float height = 5f;
	public Transform target;
	public float interpolate;
	public bool isReached = false;

	private Vector2 startPos;

	public bool isTimeDelta = true;
	public float m_Distance = 0f;
	public float remainDist = 0f;
	public float speed = 0.1f;

	void Start () 
	{
		startPos = this.transform.position;		
		m_Distance = Vector2.Distance(startPos, (Vector2)target.position);
		interpolate = 0f;
		destTime = 0f;
	}
	
	float delta = 0f;
	void Update () 
	{
		if (isReached)
			return;

		
		Vector2 tarPos = (Vector2)target.position;
		//remainDist = Vector2.Distance((Vector2)this.transform.position, tarPos);
		
		if (isTimeDelta)
		{
			interpolate += Time.deltaTime;
			delta = Mathf.Clamp((interpolate / destTime), 0f, 1f);
			//delta = Mathf.Clamp(destTime, 0f, 1f);
			Vector2 dest = MathParabola.Parabola(startPos, tarPos, height, delta);
			transform.position = dest;

			if (delta == 1f)
				interpolate = 0f;
		}
		else
		{
			//delta = Mathf.Clamp((remainDist / m_Distance), 0f, 1f);
			//delta += (Time.deltaTime * speed);
			delta = Mathf.Clamp(delta, 0f, 1f);
			Vector2 dest = MathParabola.Parabola(startPos, tarPos, height, delta);
			transform.position = dest;

			if (delta == 1f)
				delta = 0f;
		}

		// if (delta == 1f)
		// 	isReached = true;
		//interpolate = interpolate % destTime;
		
	}
}
