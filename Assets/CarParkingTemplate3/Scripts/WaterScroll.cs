//--------------------------------------------------------------
//
//                    Car Parking Template 3.0
//        
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

// This script used for Water texture scrolling offset

using UnityEngine;
using System.Collections;

public class WaterScroll : MonoBehaviour
{

	public float scrollSpeed1 = -0.07f, scrollSpeed2 = -0.07f;
	private Renderer rend;
	public string name1 = "_MainTex", name2 = "_SpecTex";

	void Start ()
	{
		if (!rend)
			rend = GetComponent<Renderer> ();
	}

	void Update ()
	{
		float offset1 = Time.time * scrollSpeed1;
		float offset2 = Time.time * scrollSpeed2;

		rend.material.SetTextureOffset (name1, new Vector2 (offset1, 0));
		rend.material.SetTextureOffset (name2, new Vector2 (offset2, 0));

	}
}
