using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehindeTheScene;
public class Mother : MonoBehaviour {


	public GameObject Child;
	public float Particles = 1000;
	public float SquareLength = 3f;
	private WanderCorelated _wandercoLast;
	public ChildType ChildType;
	public float InnerCircleRaidus = 1f;
	public void Start () {
		Application.targetFrameRate = 1000;
		if (ChildType == ChildType.Circle) {
			Circlize ();
		} else if (ChildType == ChildType.Square) {
			Rectanglize ();
		}
	}

	public void Circlize(){
		for (int i = 0; i < Particles; i++) {

			var r = UnityEngine.Random.insideUnitCircle * InnerCircleRaidus;
			var pos = new Vector3 (r.x, r.y, 0);

			var child = GameObject.Instantiate (Child, pos, Quaternion.identity);
			child.transform.parent = transform;

			var wanderco = child.GetComponent<WanderCorelated> ();
			if (wanderco) {
				if (_wandercoLast) {
					wanderco.Left = _wandercoLast;
					_wandercoLast = wanderco;
				}
			}

			var sr = child.GetComponent<SpriteRenderer>();
			sr.color = Random.ColorHSV(2f, .4f, .5f, .9f, 0.3f, 0.45f, 0.2f, 0.5f);

		}
	}

	public void Rectanglize() {
		int particle_for_each_edges = (int) (Particles / 4 );
		float step = SquareLength / (float)(particle_for_each_edges);

		for (int i = 0; i < particle_for_each_edges; i++) {
			for (int j = 0; j < particle_for_each_edges; j++) {

				float yy = -SquareLength/2 + (i * step);
				float xx = -SquareLength/2 + (j * step);
				var pos = new Vector3 (xx, yy, 0);
				var child = GameObject.Instantiate (Child, pos, Quaternion.identity);
				child.transform.parent = transform;

				var wanderco = child.GetComponent<WanderCorelated> ();
				if (_wandercoLast) {
					wanderco.Left = _wandercoLast;
					_wandercoLast = wanderco;
				}

				var sr = child.GetComponent<SpriteRenderer>();
				sr.color = Random.ColorHSV(2f, .4f, .5f, .9f, 0.2f, 0.34f, 0.2f, 0.5f);
			}
		}

			

	}

}
