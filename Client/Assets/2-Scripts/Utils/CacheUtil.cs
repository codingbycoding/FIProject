﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CacheUtil : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CleanAllCache() {
		Caching.CleanCache ();
	}
}