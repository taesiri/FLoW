using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderCorelated : MonoBehaviour {

	public float Speed = 10f;
	public float Factor = 0.001f;
	public Vector3 Target = Vector3.zero;
	public float SlideTargetTime = 1;

	private float lastChange = 0;

	public float MaxDisatnce = 10f;

	public WanderCorelated Left;
	public float Corelation = 0.02f;

	public Mother MotherJan;

	public void Start () {
		
		MotherJan = transform.parent.gameObject.GetComponent<Mother> ();

		if (MotherJan.ChildType == BehindeTheScene.ChildType.Circle) {
			var r = UnityEngine.Random.insideUnitCircle * 5f;
			Target = new Vector3 (r.x, r.y, 0);
		} else if (MotherJan.ChildType == BehindeTheScene.ChildType.Square) {
			var r = UnityEngine.Random.insideUnitCircle * 0.5f;
			Target = transform.position + new Vector3 (r.x, r.y, 0);
		}

	}
	
	public void Update ()
	{
		if (MotherJan.ChildType == BehindeTheScene.ChildType.Circle) {
			CircleUpdate ();
		} else if (MotherJan.ChildType == BehindeTheScene.ChildType.Square) {
			SquareUpdate ();
		}
	}

	public void CircleUpdate() {

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


		if (Vector3.Distance (Target, Vector3.zero) > MaxDisatnce) {
			var r = UnityEngine.Random.insideUnitCircle * 0.75f;
			Target = new Vector3 (r.x, r.y, 0);
		}

		if (Left) {
			Left.Target = Vector3.MoveTowards (Left.Target, Target, Corelation);
		}
	}

	public void SquareUpdate() {

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


		if (Vector3.Distance (Target, Vector3.zero) > MaxDisatnce) {
			var r = UnityEngine.Random.insideUnitCircle * 0.75f;
			Target = new Vector3 (r.x, r.y, 0);
		}

		if (Left) {
			Left.Target = Vector3.MoveTowards (Left.Target, Target, Corelation);
		}
	}
}
