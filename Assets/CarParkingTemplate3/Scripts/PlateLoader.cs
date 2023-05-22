//--------------------------------------------------------------
//
//                    Car Parking Template 3.0
//        
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

// This script used for load car pelak from mobile sd card in this path:/mnt/sdcard/CarParking/Pelak/

using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;
public class PlateLoader : MonoBehaviour {

	// Target renderer for assign pelak texture
	[Space(7)]
	public GameObject target1,target2;

	// Texture index on target directory => first texture or second or ...;
	[Space(7)]
	public int FileIndex;

	// Texture path on SD Card
	[Space(7)]
	public string path = @"/mnt/sdcard/CarParking/Plate/"
		;
	#if !UNITY_EDITOR && !UNITY_WEBPLAYER
	IEnumerator Start()
	{
	DirectoryInfo df = new DirectoryInfo (path);
		if (df.GetFiles ().Length >= 0) {
			
	WWW www = new WWW ("file://" + df.GetFiles () [FileIndex].FullName);
			yield return www;
	target1.GetComponent<Renderer>().material.mainTexture = www.texture;
	target2.GetComponent<Renderer>().material.mainTexture = www.texture;
			www = null;
			www.Dispose ();
		}
	}
	#endif
}
