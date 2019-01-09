﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

	public float levelSeconds = 100;
	
	private Slider slider;
	private AudioSource audioSource;
	private bool isEndOfLevel = false;
	private LevelManager levelManager;
	private GameObject winLabel;

	// Use this for initialization
	void Start ()
	{
		slider = GetComponent<Slider>();
		audioSource = GetComponent<AudioSource>();
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		FindYouWin();
		winLabel.SetActive(false);
	}

	private void FindYouWin()
	{
		winLabel = GameObject.Find("You Win");
		if (!winLabel)
		{
			Debug.LogWarning("Please create You Win object");
		}
	}

	// Update is called once per frame
	void Update ()
	{
		slider.value = Time.timeSinceLevelLoad / levelSeconds;

		bool timeIsUp = (Time.timeSinceLevelLoad >= levelSeconds);
		if(timeIsUp && !isEndOfLevel)
		{
			HandleWinCondition();
		}
	}

	private void HandleWinCondition()
	{
		DestroyAllTaggedObjects();
		audioSource.Play();
		winLabel.SetActive(true);
		Invoke("LoadNextLevel", audioSource.clip.length);
		isEndOfLevel = true;
	}

	//Destroy all objects with destroyOnWin tag
	void DestroyAllTaggedObjects()
	{
		GameObject[] taggedObjectArray = GameObject.FindGameObjectsWithTag("destroyOnWin");

		foreach (GameObject taggedObject in taggedObjectArray)
		{
			Destroy(taggedObject);
		}
	}

	void LoadNextLevel()
	{
		levelManager.LoadNextLevel();
	}
}
