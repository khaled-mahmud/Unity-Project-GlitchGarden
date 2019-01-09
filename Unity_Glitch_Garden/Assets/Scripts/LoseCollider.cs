using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;

	// Use this for initialization
	void Start ()
	{
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

	private void OnTriggerEnter2D()
	{
		levelManager.LoadLevel("03b Lose");
	}
}
