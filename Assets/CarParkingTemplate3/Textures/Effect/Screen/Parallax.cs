using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour
{
	public float speed = 0.5f;
	public float start = 0;

	Vector2 offset = new Vector2 (0, 0);

	void Update ()
	{
		offset.x = start + Time.time * speed;

		GetComponent<UnityEngine.UI.Image>().material.mainTextureOffset = offset;
	}
}