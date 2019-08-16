using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputReader : MonoBehaviour {

	[SerializeField] Text minText, maxText;
	private int min, max;

	void Awake(){
		if(FindObjectsOfType<InputReader>().Length > 1){
			Debug.Log("Fui destruido :(");
			Destroy(gameObject);
		} else{
			DontDestroyOnLoad(gameObject);
		}
	}

	public void ReadInput(){
		min = int.Parse(minText.text);
		max = int.Parse(maxText.text);
	}
	
	public int[] GetInput(){
		int[] input = {min,max};
		Destroy(gameObject);
		return input;
	}
}
