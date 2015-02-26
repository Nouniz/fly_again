using UnityEngine;
using System.Collections;

public class fire : MonoBehaviour {

	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = new Vector2 (4, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log(other.gameObject.name);
		if (other.gameObject.name == "bomb(Clone)") {
			Instantiate (Resources.Load("explose"), other.gameObject.transform.position, other.gameObject.transform.rotation);
			Destroy (other.gameObject);
		}
		Destroy (this.gameObject);
	}
}
