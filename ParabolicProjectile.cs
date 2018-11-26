using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolicProjectile : MonoBehaviour {

	public float destTime = 2f;
	public float height = 5f;
	public Transform target;
	public float interpolate;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		interpolate += Time.deltaTime;
		interpolate = interpolate % destTime;
		//transform.position = MathParabola.Parabola(Vector3.zero, Vector3.forward * 10f, 5f, Animation / destTime);
		transform.position = MathParabola.Parabola(Vector3.zero, target.position, height, interpolate / destTime);
	}
}
