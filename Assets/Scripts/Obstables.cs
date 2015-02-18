using UnityEngine;
using System.Collections;

public class Obstables : MonoBehaviour {

	public Vector2 velocity = new Vector2(-4, 0);
	public float range = 4;
	
	// Use this for initialization
	void Start()
	{
		rigidbody2D.velocity = velocity;
		//position aléatoires des obstacles
		transform.position = new Vector3(transform.position.x - range * Random.value, transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
