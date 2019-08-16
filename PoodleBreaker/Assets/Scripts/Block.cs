using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
	
    [SerializeField] private AudioClip _hitClip;
    private Level _level;

    [SerializeField] private Sprite[] _hitSprites;
    private int _HP;
    private SpriteRenderer _spriteRenderer;


	private void Start() {
        if(tag == "Unbreakable") return;
       _level = FindObjectOfType<Level>();
       _level.AddBlock();
   }

	private void DestroyBlock() {
       _level.RemoveBlock();
       Destroy(gameObject, 0);
   }

	private void OnCollisionEnter2D(){
        if(tag == "Unbreakable") return;
        AudioSource.PlayClipAtPoint(_hitClip, gameObject.transform.position);
		DestroyBlock();
	}
}
