using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour {

	public float Speed = 1f;
	public Vector3 Direction = Vector3.zero;
	public float LenX = 4f;
	public float LenY = 4f;
	public float epsilon = 0.01f;
	public float CircleRaidus = 4f;
	public BouncerType BounceType = BouncerType.Circle;
	public bool NormalBehave = true;
	public Vector3 SecondForceField  = Vector3.down * 0.1f;
	public enum BouncerType {
		Circle,
		Rectangle
	}
	// Update is called once per frame
	void Update () {
		if(NormalBehave) {
			transform.position += Time.deltaTime*Direction*Speed;
			if(BounceType == BouncerType.Circle) {
				var dist = Vector3.Distance(transform.position, Vector3.zero);

				var sr = GetComponent<SpriteRenderer>();
				// sr.color = Random.ColorHSV(.2f, 1f, .2f, .6f, 0.2f, 0.5f, 0.1f, 0.4f);

				sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1- (dist/CircleRaidus));
				
				if (dist > CircleRaidus) {
					Direction *= -1;
					GameObject.Destroy(this);
				}


			} else if (BounceType == BouncerType.Rectangle) {
				if (transform.position.x - LenX > epsilon ) {
					Direction  = new Vector3(Direction.x*-1, Direction.y, 0);
				} else if (transform.position.x + LenX < epsilon ) {
					Direction  = new Vector3(Direction.x*-1, Direction.y, 0);
				}
				else if (transform.position.y - LenY  > epsilon ) {
					Direction  = new Vector3(Direction.x, Direction.y*-1, 0);
				} else if (transform.position.y + LenY < epsilon ) {
					Direction  = new Vector3(Direction.x, Direction.y*-1, 0);
				}
			}
		} else {
			

			transform.position += Time.deltaTime*(Direction+SecondForceField)*Speed ;
			if(BounceType == BouncerType.Circle) {
				var dist = Vector3.Distance(transform.position, Vector3.zero);

				var sr = GetComponent<SpriteRenderer>();
				sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1- (dist/CircleRaidus));
				
				if (dist > CircleRaidus) {
					Direction *= -1;
					GameObject.Destroy(this);
				}
			} else if (BounceType == BouncerType.Rectangle) {
				if (transform.position.x - LenX > epsilon ) {
					Direction  = new Vector3(Direction.x*-1, Direction.y, 0);
				} else if (transform.position.x + LenX < epsilon ) {
					Direction  = new Vector3(Direction.x*-1, Direction.y, 0);
				}
				else if (transform.position.y - LenY  > epsilon ) {
					Direction  = new Vector3(Direction.x, Direction.y*-1, 0);
				} else if (transform.position.y + LenY < epsilon ) {
					Direction  = new Vector3(Direction.x, Direction.y*-1, 0);
				}
			}

		}
	}
}
