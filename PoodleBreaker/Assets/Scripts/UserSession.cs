using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserSession : MonoBehaviour {
	[SerializeField] private Text _nameText;

	private string _name;
	private int _score;

	private LevelManager _levelManager;

	private void Start() {
		_levelManager = FindObjectOfType<LevelManager>();
		FindObjectOfType<MusicManager>().PlayStartMenuMusic();
	}

	public void EndGameSession(int score){
		_score = score;
		_levelManager.LoadSceneByName("Game Over");
	}

	public string GetScoreAndDestroy(){
		Destroy(gameObject);
		return _name + " - " + _score;
	}

	public void GetName(){
		_name = _nameText.text;
		Debug.Log(_name);
	}

	private void Awake() {
		if(FindObjectsOfType<UserSession>().Length > 1){
			Destroy(gameObject);
		} else {
			DontDestroyOnLoad(gameObject);
		}
	}

}
