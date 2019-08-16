using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {
 	// Armazenas as músicas de cada estado
    [SerializeField] private AudioClip _startMenuMusic;
    [SerializeField] private AudioClip[] _levelMusics;
    [SerializeField] private AudioClip _loseLevelMusic;
    [SerializeField] private AudioClip _winLevelMusic;
    
    // Armazena o volume de cada música
    [SerializeField] private float _startMenuMusicVolume = 0.2f;
    [SerializeField] private float _levelMusicsVolume = 0.2f;
    [SerializeField] private float _loseLevelMusicVolume = 0.2f;
    [SerializeField] private float _winLevelMusicVolume = 0.2f;
    
    // Armazena as referências
    private AudioSource _audioSource;
	// Use this for initialization
	
    private void Awake() {
        if(FindObjectsOfType<MusicManager>().Length > 1){
            Destroy(gameObject);
        }
        else{
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start () {
		_audioSource = GetComponent<AudioSource>();
	}
	
	// Toca a música da vitória
    public void PlayWinLevelMusic() {
        _audioSource.volume = _winLevelMusicVolume;
        _audioSource.clip = _winLevelMusic;
        _audioSource.loop = false;

        _audioSource.Play();
    }
    
    // Toca a música da derrota
    public void PlayLoseLevelMusic() {
        _audioSource.volume = _loseLevelMusicVolume;
        _audioSource.clip = _loseLevelMusic;
        _audioSource.loop = false;

        _audioSource.Play();
    }

	// Toca a música do menu inicial
    public void PlayStartMenuMusic() {
        _audioSource.volume = _startMenuMusicVolume;
        _audioSource.clip = _startMenuMusic;
        _audioSource.loop = true;
        
        _audioSource.Play();
    }
    
    // Toca a música do level dado
    public void PlayLevelMusic(int level) {
        if (level >= _levelMusics.Length) {
            Debug.LogError("Can't find music for level " + level);
        }
        
        _audioSource.volume = _levelMusicsVolume;
        _audioSource.clip = _levelMusics[level];
        _audioSource.loop = true;
        
        _audioSource.Play();
    }


}
