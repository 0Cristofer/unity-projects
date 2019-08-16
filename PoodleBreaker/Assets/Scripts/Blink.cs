using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour {

	public float blinkInterval = 0.5f;
	private bool _isActive = true;

	private void Start() {
		InvokeRepeating("Toogle", blinkInterval, blinkInterval);
	}

	private void Toogle() {
		gameObject.SetActive(_isActive);
		
		_isActive = !_isActive;		
	}

}
