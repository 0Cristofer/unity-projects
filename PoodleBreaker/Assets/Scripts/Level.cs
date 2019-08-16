using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

	private GameSession _gameSession;

	private Ball _ball;
	private Paddle _paddle;
	private bool _isBallLocked = true;
	private Vector2 _distanceToPaddle;

	private int _numberBreakableBlocks = 0;
	private int _pointsPerBlock = 12;
	private int _currentScore;

	public void AddBlock(){
		_numberBreakableBlocks++;
	}

	public void RemoveBlock() {
        _currentScore = _currentScore + _pointsPerBlock;
		_gameSession.UpdateScoreUI(_currentScore);

        _numberBreakableBlocks = _numberBreakableBlocks - 1;
        
        if (_numberBreakableBlocks == 0) {
            _ball.gameObject.SetActive(false);
            _gameSession.WinLevel(_currentScore);
        }
    }


	// Use this for initialization
	void Start () {
		_ball = FindObjectOfType<Ball>();
		_paddle = FindObjectOfType<Paddle>();
		_gameSession = FindObjectOfType<GameSession>();

		_distanceToPaddle = _ball.transform.position - _paddle.transform.position; 
		_gameSession.StartLevel();
	}
	
	// Update is called once per frame
	void Update () {
		if(_isBallLocked){
			if(Input.GetMouseButtonUp(0)){
				LaunchBall();
			}
			else{
				_ball.LockBall(_paddle.transform.position, _distanceToPaddle);
			}
		}
	}

	private void LaunchBall(){
		_isBallLocked = false;
		_ball.LaunchBall();
	}

	public void LoseLevel(){
		_gameSession.LoseLevel(_currentScore);
	}
}
