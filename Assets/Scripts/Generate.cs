using UnityEngine;
using System.Collections;

public class Generate : MonoBehaviour {
	
	public GameObject rocks;
	public GameObject bombs;

	int score = 0;
	
	// Use this for initialization
	void Start()
	{
		switch (GameModeSelect.instance.gameMode) {
			case GameMode.CLASSIQUE:
				InvokeRepeating("CreateRoks", 2f, 2.5f);
				InvokeRepeating("CreateBomb", 1f, 3.5f);
			break;
			case GameMode.ARM:
			InvokeRepeating("CreateRoks", 1f, 1.5f);
			break;
		}

	}
	
	void CreateRoks()
	{
		Instantiate (rocks);
		score++;
	}

	void CreateBomb()
	{
		Instantiate (bombs);
		//score++;
	}
	// Update is called once per frame
	void OnGUI () 
	{
		GUI.color = Color.black;
		GUILayout.Label(" Score: " + score.ToString());
	}
	
	// Update is called once per frame
	void Update () {
	}
}
