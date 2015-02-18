using UnityEngine;
using System.Collections;

public class Generate : MonoBehaviour {
	
	public GameObject rocks;
	
	// Use this for initialization
	void Start()
	{
		InvokeRepeating("CreateObstacle", 2f, 2.5f);
	}
	
	void CreateObstacle()
	{
		Instantiate (rocks);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
