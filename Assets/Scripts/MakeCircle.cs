using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeCircle : MonoBehaviour {	
	public int Resolution = 10;	
	public float Raidus = 10;
	private LineRenderer ld;
	// Use this for initialization
	public Vector3[] poses;
	public Color ColorA;
	public Color ColorB;

	public float MaxDistance = 1f;
	public float MinDistance = -1f;

	void Start () {

		ld = GetComponent<LineRenderer>();

		var centre = transform.position;
		poses = new Vector3[Resolution];
		
		


		var arcSize = Mathf.PI*2/(float)Resolution;
		for(int i=0; i< Resolution; i++) {
			var x = Mathf.Cos(arcSize*i)*Raidus;
			var y = Mathf.Sin(arcSize*i)*Raidus;
			poses[i] = new Vector3(x, y , 0) + centre;
		}

		ld.positionCount = Resolution;
		ld.SetPositions(poses);


		ld.material = new Material(Shader.Find("Sprites/Default"));


		Gradient gradient = new Gradient();
		float alpha = 0.01f;
		gradient.SetKeys(
			new GradientColorKey[] { new GradientColorKey(ColorA, 0.0f), new GradientColorKey(ColorB, 1.0f) },
			new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
		);
		ld.colorGradient = gradient;
	}
	
	// Update is called once per frame
	void Update () {
		
		var displacements = new Vector3[poses.Length];

		for(int i=0; i< Resolution; i++) {
			displacements[i] = (new Vector3(1,1,0)) * Random.Range(MinDistance,MaxDistance)/1000f;
		}

		// Worst way to smoothing!!!
		for(int i = 1; i < Resolution-1; i++){
			displacements[i] = ( displacements[i-1] + displacements[i+1]) / 2f;
		}
		displacements[0] =(displacements[displacements.Length-1] + displacements[1]) / 2f;
		displacements[displacements.Length-1] =(displacements[displacements.Length-2] + displacements[0]) / 2f;


		// Worst way to smoothing!!! second time!
		for(int i = 1; i < Resolution-1; i++){
			displacements[i] = ( displacements[i-1] + displacements[i+1]) / 2f;
		}
		displacements[0] =(displacements[displacements.Length-1] + displacements[1]) / 2f;
		displacements[displacements.Length-1] =(displacements[displacements.Length-2] + displacements[0]) / 2f;

		// Worst way to smoothing!!! third time!
		for(int i = 1; i < Resolution-1; i++){
			displacements[i] = ( displacements[i-1] + displacements[i+1]) / 2f;
		}
		displacements[0] =(displacements[displacements.Length-1] + displacements[1]) / 2f;
		displacements[displacements.Length-1] =(displacements[displacements.Length-2] + displacements[0]) / 2f;



		// Adding displacements
		for(int i=0; i< Resolution; i++) {
			poses[i] += displacements[i] ; 
		}

		ld.SetPositions(poses);

	}
}
