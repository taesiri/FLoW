using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour {


	public LineRenderer MainLineRederer;

	// Use this for initialization
	void Start () {
		MainLineRederer = GetComponent<LineRenderer>();
		var x = new [] {29,29,75,73,27,19,1,20,19,88,227,249,255,251,191,130,110,115,118,127,154,154};
		var y = new [] {152,121,119,65,65,53,56,39,19,9,0,0,5,8,34,50,60,75,116,119,121,149};


		MainLineRederer.positionCount = x.Length;
		var ppps = new List<Vector3>();

		for(int i = 0; i < x.Length; i++) {
			var a = new Vector3(x[i], y[i], 0);
			ppps.Add(a);
		}
		
		MainLineRederer.SetPositions(ppps.ToArray());

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
