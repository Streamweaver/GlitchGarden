﻿using UnityEngine;
using System.Collections;

public class SplashScreenManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		LevelManager mgr = GameObject.Find ("LevelManager").GetComponent<LevelManager> ();
		StartCoroutine (mgr.LoadLevelDelay ("01_MainMenu", 3f));
	}
}
