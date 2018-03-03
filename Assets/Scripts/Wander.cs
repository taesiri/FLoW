using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour {

	public float Speed = 10f;
	public float Factor = 0.001f;
	public Vector3 Target = Vector3.zero;
	public float SlideTargetTime = 1;
	public float MaxDistance = 2.9f;

	private float lastChange = 0;

	public Mother MotherJan;

	// Use this for initialization
	public void Start () {
		var r = UnityEngine.Random.insideUnitCircle * 5f;
		Target = new Vector3 (r.x, r.y, 0);

		MotherJan = transform.parent.gameObject.GetComponent<Mother> ();
	}
	
	public void Update ()
	{
		var dirNormalized = (Target - transform.position).normalized;

		if (Vector3.Distance (Target, transform.position) >= 0.1f) {
			transform.position = transform.position + (dirNormalized * Speed * Factor * Time.deltaTime);
		}

		if (Time.time - lastChange > SlideTargetTime) {
			lastChange = Time.time;
			var r = UnityEngine.Random.insideUnitCircle * 0.2f;
			Target += new Vector3 (r.x, r.y, 0);


			var s = UnityEngine.Random.Range (1, 1000) / 1000f;
			Speed += s;
		}


		if (Vector3.Distance (Target, Vector3.zero) > MaxDistance) {
			var r = UnityEngine.Random.insideUnitCircle * 0.75f;
			Target = new Vector3 (r.x, r.y, 0);
		}
	}
}
