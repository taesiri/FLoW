using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidPixel : MonoBehaviour {

	public float TimeToExplode = 2f;
	public float ForceStrength = 2.5f;
	public Vector2 ForceDirection = Vector3.left;

	public bool RandomizeDirection = false;

	void Start () {
		Invoke("LaunchParticle", TimeToExplode);


		if(RandomizeDirection){
			ForceDirection = UnityEngine.Random.insideUnitCircle;
		}

	}

	public void LaunchParticle () {

		GetComponent<Rigidbody2D>().AddForce(ForceDirection*ForceStrength, ForceMode2D.Impulse);
	}
}
