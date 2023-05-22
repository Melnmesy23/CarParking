//--------------------------------------------------------------
//
//                    Car Parking Template 3.0
//        
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;
public class ImageLoader : MonoBehaviour {

	// Use this for initialization
	public Image Plate;

	public string path  =  @"/mnt/sdcard/CarParking/Plate/";

	#if !UNITY_EDITOR && !UNITY_WEBPLAYER
	IEnumerator Start () {
		if(!Directory.Exists(path))
			Directory.CreateDirectory(path);

	DirectoryInfo PlateInfo = new DirectoryInfo(path);
	WWW n = new WWW("file://"+PlateInfo.GetFiles()[0].FullName);
		yield return n;
	Plate.sprite = Sprite.Create(n.texture, new Rect(0, 0, n.texture.width, n.texture.height),new Vector2(0, 0),100.0f);
	}
	#endif
}
