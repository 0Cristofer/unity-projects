using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSession : MonoBehaviour {

	// Referencias aos objetos
	private LevelManager _levelManager;
	private UserSession _userSession;
	[SerializeField] private Text _textScore;
	private MusicManager _musicManager;


	// Variáveis de estado
	[SerializeField] private int _numberOfLevels;
	private int _currentLevel = 0;
	private int _currentScore = 0;

	// É um singleton
	private void Awake(){
		if(FindObjectsOfType<GameSession>().Length > 1){
			Destroy(gameObject);
		}
		else{
			DontDestroyOnLoad(gameObject);
		}
	}

	// Inicializa as referências
	void Start () {
		_levelManager = FindObjectOfType<LevelManager>();
		_userSession = FindObjectOfType<UserSession>();
		_musicManager = FindObjectOfType<MusicManager>();
	}

	public void UpdateScoreUI(int score) {
        _textScore.text = score.ToString();
	}

	public void WinLevel(int score){
		_currentLevel = _currentLevel + 1;
		_currentScore = _currentScore + score;

		if(_currentLevel == _numberOfLevels){
			DestroySession();
		}
		else{
			_levelManager.LoadNextScene();
		}
	}

	public void LoseLevel(int score){
		_currentScore = _currentScore + score;

		DestroySession();
	}

	public void StartLevel(){
		_musicManager.PlayLevelMusic(_currentLevel);
	}
	
	private void DestroySession(){
		Destroy(gameObject);
		_userSession.EndGameSession(_currentScore);		
	}
}
