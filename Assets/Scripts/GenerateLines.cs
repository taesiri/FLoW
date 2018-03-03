using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLines : MonoBehaviour {

	public GameObject LineObjectPrefab;
	public Material LineMaterial;
	public int Counter = 10;
	public bool ToggleDepth = false;

	public Color ColorA;
	public Color ColorB;

	void Start () {
		
		if(ToggleDepth){
			Camera.main.clearFlags =  CameraClearFlags.Nothing;
		} else {
			Camera.main.clearFlags =  CameraClearFlags.SolidColor;
		}

		for(int i=0; i<Counter; i++) {

			var g = GameObject.Instantiate(LineObjectPrefab);
			g.transform.parent = this.transform;

			var ld = g.GetComponent<LineRenderer>();
			ld.sharedMaterial = LineMaterial;
			ld.startWidth = 0.01f;
			ld.endWidth = 0.01f;
			ld.positionCount = 2;

			ld.SetPosition(0, new Vector3(-10, 0, 2*i));
			ld.SetPosition(1, new Vector3(10, 0, 2*i));

			g.name = "ld-" + i.ToString();


			ld.material = new Material(Shader.Find("Sprites/Default"));
			
			float alpha = 0.01f;
		
			Gradient gradient = new Gradient();
			if(ToggleDepth){
				alpha = 0.01f;
			} else {
				alpha = 1f;
			}
			
			gradient.SetKeys(
					new GradientColorKey[] { new GradientColorKey(ColorA, 0.0f), new GradientColorKey(ColorB, 1.0f) },
					new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
					);
			ld.colorGradient = gradient;
		
			g.GetComponent<LineShaker>().ReadyToGo();
			
			
		}

	}
	
	void Update () {
		
	}
}
