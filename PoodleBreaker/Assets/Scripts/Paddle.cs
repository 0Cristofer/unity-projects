using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	[SerializeField] private float _cameraSize;
	private float _aspectRatio, _sizeX;
	[SerializeField] private float _maxX, _minX;
	
	private void Start () {
		_cameraSize = Camera.main.orthographicSize; // Não é necessário, apenas para refernciar a câmera
		_aspectRatio = Screen.width / (float)Screen.height;
		_sizeX = _cameraSize * 2 * _aspectRatio;
	}
	
	private void Update () {
		float mousePosX = (Input.mousePosition.x / Screen.width) * _sizeX;
		var newPos =  new Vector2(mousePosX, transform.position.y);
		
		newPos.x = Mathf.Clamp(mousePosX, _minX, _maxX);
		
		transform.position = newPos;
	}

}
