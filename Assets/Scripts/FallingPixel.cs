using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPixel : MonoBehaviour {

	public float Speed = 1f;
	public Vector3 Target = Vector3.left * 10; 
	public float Factor = 0.1f;
	
	public int i = 0;
	public int j = 0;

	public float posx = 0;
	public float posy = 0;

	public	void Start () {
		Application.targetFrameRate = 300;

		Speed += UnityEngine.Random.Range (-2000, 2000)  / 4000f;

//		var r = UnityEngine.Random.insideUnitCircle * 5f;
//		Target += transform.position + new Vector3 (r.x, r.y, 0);

		Target = new Vector3 (i, j, 0) / 10f;
	}
	
	// Update is called once per frame
	void Update () {
		
//		if ( 40 < i && i < 110 ) {
//			var dirNormalized = (Target - transform.position).normalized;
//
//			if (Vector3.Distance (Target, transform.position) >= 0.1f) {
//				transform.position = transform.position + (dirNormalized * Speed * Factor * Time.deltaTime);
//			} else {
//				transform.position = new Vector3 (i, j, 0) / 10f;
//			}
//		}

		var dirNormalized = (Target - transform.position).normalized;

		if (Vector3.Distance (Target, transform.position) >= 0.1f) {
			transform.position = transform.position + (dirNormalized * Speed * Factor * Time.deltaTime);
		} else {
			transform.position = new Vector3 (i, j, 0) / 10f;
		}
	}
}
