﻿using UnityEngine;
using System.Collections;

public class Obstables : MonoBehaviour {

	public Vector2 velocity = new Vector2(-4, 0);
	public float range = 2;
	
	// Use this for initialization
	void Start()
	{
		rigidbody2D.velocity = velocity;
		switch (GameModeSelect.instance.gameMode) {
		case GameMode.CLASSIQUE:
			//position aléatoires des obstacles
			transform.position = new Vector3(transform.position.x, transform.position.y - range * Random.value, transform.position.z);
			break;
		case GameMode.ARM:
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (this.gameObject.name+" "+this.gameObject.transform.position.x+ " "+Screen.width);
		if (this.gameObject.transform.position.x < -30) {
			//Debug.Log ("DESTROYED");
			Destroy(this.gameObject);
		}
	}
}
