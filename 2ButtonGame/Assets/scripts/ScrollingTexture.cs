using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingTexture : MonoBehaviour {

	public float scrollspeedX = 0.1f;
	public float scrollspeedY = 0.5f;
	Material offset;


	// Use this for initialization
	void Start () {

		offset = gameObject.GetComponent<MeshRenderer> ().material;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		float offsetX = Time.time * scrollspeedX;
		float offsetY = Time.time * scrollspeedY;
		offset.mainTextureOffset = new Vector2 (offsetX,offsetY);
		//print ();
	}
}
