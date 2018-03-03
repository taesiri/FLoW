using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineShaker : MonoBehaviour {

	private LineRenderer ld;
	private Vector3 initA;
	private Vector3 initB;
	public int Resolution = 50;
	public Vector3[] xOffsets;
	public float[] yOffsets;
	public Vector3[] arraysOfPoints;
	public AnimationCurve WaveCurve;
	public bool RandomShake = false;
	public float RandomShakeMaxY = 8f;
	public float RandomShakeMinY = -3f;
	public float RandomShakeScaleFactor = 30f;

	public void ReadyToGo () {
		ld = GetComponent<LineRenderer>();
		initA = ld.GetPosition(0);
		initB = ld.GetPosition(1);

		xOffsets = new Vector3[Resolution];
		arraysOfPoints = new Vector3[Resolution]; 
		yOffsets = new float[Resolution];

		for(int i =0; i < Resolution; i++) {
			var tt = (i/(float)Resolution);
			xOffsets[i] = Vector3.Lerp(initA, initB, tt);
			yOffsets[i] = Random.Range(0,10)/20f;
			arraysOfPoints[i] = xOffsets[i] + (WaveCurve.Evaluate(tt) * yOffsets[i]*Vector3.up);
		}
		ld.positionCount = Resolution;
		ld.SetPositions(arraysOfPoints);

		InvokeRepeating("ShiftArray", 0.1f, 0.05f);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void ShiftArray() {

		var startElement = yOffsets[0];
		var newArray = new float[yOffsets.Length];
        System.Array.Copy(yOffsets, 1, newArray, 0, yOffsets.Length - 1);
		newArray[yOffsets.Length-1] = startElement;

		var pts = new Vector3[Resolution]; 
		for(int i =0; i < Resolution; i++) {
			var tt = (i/(float)Resolution);
			if(!RandomShake){
				pts[i] = xOffsets[i] + (WaveCurve.Evaluate(tt) * newArray[i]*Vector3.up);
			} else {
				newArray[i] += Random.Range(RandomShakeMinY,RandomShakeMaxY)/RandomShakeScaleFactor;
				pts[i] = xOffsets[i] + (WaveCurve.Evaluate(tt) * newArray[i]*Vector3.up);
			}
		}

		ld.SetPositions(pts);
		yOffsets = newArray;

	}
}
