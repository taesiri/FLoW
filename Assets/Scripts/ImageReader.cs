using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageReader : MonoBehaviour {

	public Texture2D sourceTex;
	public Rect sourceRect;

	public bool isFalling = false;

	public GameObject PixelElement;
	void Start()
	{
		int x = Mathf.FloorToInt(sourceRect.x);
		int y = Mathf.FloorToInt(sourceRect.y);
		int width = Mathf.FloorToInt(sourceRect.width);
		int height = Mathf.FloorToInt(sourceRect.height);

		Color[] pix = sourceTex.GetPixels(x, y, width, height);


		for (int i = 0; i < width; i++) {
			for (int j = 0; j < height; j++) {

				var ppp = GameObject.Instantiate (PixelElement, new Vector3 (i, j, 0)/10f , Quaternion.identity);


				var col = pix [(i * width) + j];
				ppp.GetComponent<SpriteRenderer> ().color = new Color(col.r, col.g, col.b, 0.75f); 
				ppp.transform.parent = transform;

				if(isFalling){
					var fp = ppp.GetComponent<FallingPixel>();
					fp.i = i;
					fp.j = j;

					var r = UnityEngine.Random.insideUnitCircle * 15f;
					ppp.transform.position += new Vector3 (r.x, r.y, 0);
				} else {

					

				}


					

				ppp.GetComponent<SpriteRenderer> ().color = Random.ColorHSV(.7f, .9f, .4f, .7f, 0.2f, 0.6f, 0.2f, 0.5f); // = new Color(col.r, col.g, col.b, 0.75f); 

			}
		}
	}
}
