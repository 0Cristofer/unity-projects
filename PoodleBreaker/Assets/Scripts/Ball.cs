using UnityEngine;

public class Ball : MonoBehaviour {
	// Variáveis modificáveis no editor
	[SerializeField] private float _pushX, _pushY;
	[SerializeField] private AudioClip[] _bounceClips;
	private AudioSource _audioSource;

	private Rigidbody2D _rigidBody2D;

	// Inicializa as variáveis
	void Start () {
		_rigidBody2D = GetComponent<Rigidbody2D>();		
		_audioSource = GetComponent<AudioSource>();
	}

	public void LockBall(Vector2 paddlePos, Vector2 distanceToPaddle){
		var newPos = paddlePos + distanceToPaddle;
		_rigidBody2D.bodyType = RigidbodyType2D.Kinematic;

		transform.position = newPos;
	}

	public void LaunchBall(){
		_rigidBody2D.bodyType = RigidbodyType2D.Dynamic;
		_rigidBody2D.velocity = new Vector2(_pushX, _pushY);
	}

	private void OnCollisionEnter2D(Collision2D other) {
		var clip = _bounceClips[Random.Range(0, _bounceClips.Length)];
		_audioSource.PlayOneShot(clip);
	}
}
