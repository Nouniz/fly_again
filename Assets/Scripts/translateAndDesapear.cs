using UnityEngine;
using System.Collections;

public class translateAndDesapear : MonoBehaviour {

	// Use this for initialization
	void Start () {

		rigidbody2D.velocity = new Vector2 (-4, 0);
		Destroy (this.gameObject, 2);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
