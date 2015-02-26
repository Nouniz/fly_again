using UnityEngine;
using System.Collections;

public class DeplacerBomb : MonoBehaviour {

	public Vector2 velocity = new Vector2(-4, 0);
	public float range = 4;
	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = velocity;
		switch (GameModeSelect.instance.gameMode) {
		case GameMode.CLASSIQUE:
			//position aléatoires des obstacles
			transform.position = new Vector3(transform.position.x + 10 + range * Random.value, transform.position.y - range * Random.value, transform.position.z);
			break;
		case GameMode.ARM:
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (this.gameObject.transform.position.x < -30) {
			//Debug.Log ("DESTROYED");
			Destroy(this.gameObject);
		}
	}
}
