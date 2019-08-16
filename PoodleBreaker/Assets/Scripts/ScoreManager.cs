using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	[SerializeField] private Text _scoreText;
	private UserSession _userSession;

	// Use this for initialization
	void Start () {
		_userSession = FindObjectOfType<UserSession>();

		_scoreText.text = _userSession.GetScoreAndDestroy();
	}
}
