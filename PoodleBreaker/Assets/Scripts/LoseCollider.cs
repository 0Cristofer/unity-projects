using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

	private Level _level;

	// Use this for initialization
	void Start () {
		_level = FindObjectOfType<Level>();
	}
	
	private void OnTriggerEnter2D(Collider2D other) {
		_level.LoseLevel();
	}
}
