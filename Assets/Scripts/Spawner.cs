using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject Child;
	public float Particles = 1000;
	public float Raidus = 3;

	void Start () {

		Application.targetFrameRate = 1000;
		for (int i = 0; i < Particles; i++) {

			var r = UnityEngine.Random.insideUnitCircle * Raidus;
			var pos = new Vector3 (r.x, r.y, 0);

			var child = GameObject.Instantiate (Child, pos, Quaternion.identity);
			child.transform.parent = transform;

			var sr = child.GetComponent<SpriteRenderer>();
			sr.color = Random.ColorHSV(.6f, .8f, .7f, 1f, .2f, .4f, .1f, .4f);

			var bc =  child.GetComponent<Bouncer>();
			r = UnityEngine.Random.insideUnitCircle;
			var dir = new Vector3 (Mathf.Abs(r.x), r.y, 0);
			bc.Direction = dir;
		}
		
	}
	
	void Update () {
		
	}
}
