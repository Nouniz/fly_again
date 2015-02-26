using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	private int vies = 5;
	public GameObject rocket;
	// Use this for initialization
	void Start () {
	
	}

	public Vector2 jumpForce = new Vector2(0, 300);
	
	// Update is called once per frame
	void Update ()
	{
		if (vies == 0) {
			Die();
		}
		// Mort si on sort de l'écran
		Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
		if (screenPosition.y > Screen.height || screenPosition.y < 0)
		{
			vies--;
		}

		switch (GameModeSelect.instance.gameMode) {
		case GameMode.CLASSIQUE:
				if (Input.GetKeyUp("right"))
				{
				rocket.transform.position = transform.position + Vector3.right * 2;
					Instantiate(rocket);
				}
				// saut
				if (Input.GetKeyUp("space"))
				{
					rigidbody2D.velocity = Vector2.zero;
					rigidbody2D.AddForce(jumpForce);
				}
				break;
		case GameMode.ARM: 
				// saut
				if (Input.GetKeyDown("space"))
				{
					
					rigidbody2D.velocity = Vector2.zero;
					//rigidbody2D.AddForce(jumpForce);
					rigidbody2D.gravityScale = 0;
				}
				else if(Input.GetKeyUp("space"))
				{
					rigidbody2D.velocity = Vector2.zero;
					//rigidbody2D.AddForce(jumpForce);
					rigidbody2D.gravityScale = 1;
				}
				break;
		}

	}
	// mort à la collision
	void OnCollisionEnter2D(Collision2D other)
	{
		//Debug.Log (other.gameObject.name);
		Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
		if (screenPosition.y > Screen.height || screenPosition.y < 0 || screenPosition.x < 0)
		{
			Die();
		}
	}
	void OnTriggerEnter2D(Collider2D other) {
		Instantiate (Resources.Load("explose"), other.gameObject.transform.position, other.gameObject.transform.rotation);
		Destroy (other.gameObject);
		vies--;
	}
	void OnGUI () 
	{
		GUI.color = Color.black;
		GUILayout.Label("                 Vies: "+vies.ToString());

	}
	
	void Die()
	{
		Application.LoadLevel(Application.loadedLevel);
	}
}
