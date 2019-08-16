using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
	public void LoadSceneByName(string name){
		SceneManager.LoadScene(name);
	}

	public void LoadSceneByIndex(int index){
		SceneManager.LoadScene(index);		
	}

	public void LoadNextScene(){
		var total = SceneManager.sceneCountInBuildSettings;
		var atual = SceneManager.GetActiveScene().buildIndex;
		var prox = (atual + 1) % total;

		SceneManager.LoadScene(prox);
	}

	public void QuitGame(){
		Application.Quit();
	}
}
