using UnityEngine;
using System.Collections;

public enum GameMode {
	CLASSIQUE,
	ARM
}

public class GameModeSelect : MonoBehaviour {
	
	private static GameModeSelect _instance;
	
	private GameModeSelect() {}
	
	public static GameModeSelect instance
	{
		get 
		{
			if (_instance == null)
			{
				_instance = new GameModeSelect();
			}
			return _instance;
		}
		set {}
	}
	public GameMode gameMode;
	
	// Update is called once per frame
	void Awake () {
		if(_instance == null)
		{
			//If I am the first instance, make me the Singleton
			_instance = this;
		}
		else
		{
			//If a Singleton already exists and you find
			//another reference in scene, destroy it!
			if(this != _instance)
				Destroy(this);
		}
	}
}