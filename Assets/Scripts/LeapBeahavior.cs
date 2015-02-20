using UnityEngine;
using System.Collections;
using Leap;

public class LeapBeahavior : MonoBehaviour {

	public Vector3 positionMain;
	public Vector2 jumpForce = new Vector2(0, 10);

	public float jumpLimit = 10;
	private float jumpLimitRateOfChange;

	Controller controller;
	// Use this for initialization
	void Start () {
		controller = new Controller();
	}
	
	// Update is called once per frame
	void Update () {
		Frame frame = controller.Frame();

		// do something with the tracking data in the frame.
		HandList hands = frame.Hands;
		Vector mainDroite = hands.Rightmost.PalmPosition;

		Vector3 mainDroiteV3 = ConvertVectorToVector3(mainDroite);
		if (hands.Count == 1) {
			switch (GameModeSelect.instance.gameMode) {
			case GameMode.CLASSIQUE:
				if (mainDroiteV3.y > jumpLimit) {
					rigidbody2D.velocity = Vector2.zero;
					rigidbody2D.AddForce (jumpForce);
				}
				jumpLimit = Mathf.SmoothDamp (jumpLimit, mainDroiteV3.y, ref jumpLimitRateOfChange, 1f);  
				break;
			case GameMode.ARM:
				if (mainDroiteV3.y > 100) {
					rigidbody2D.velocity = Vector2.zero;
					rigidbody2D.gravityScale = 0;
				} else {
					rigidbody2D.gravityScale = 1;
				}
				break;
			}
		}


	}

	Vector3 ConvertVectorToVector3 (Vector unVector) {
		return new Vector3(unVector.x, unVector.y, -unVector.z);
	}

}
