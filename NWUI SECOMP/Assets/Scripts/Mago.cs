using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mago : MonoBehaviour {
	[SerializeField] LevelManager levelManager;
	[SerializeField] private int startMin, startMax;
	[SerializeField] Text gameText; //Referenciado pelo editor
	[SerializeField] Text tentativasText; //Referenciado pelo editor
	private int min, max, tentativa, numTentativas;


	// Use this for initialization
	void Start () {
		var input = FindObjectOfType<InputReader>().GetInput();

		startMin= input[0];
		startMax= input[1];
		startMax += 1;
		
		InitGame();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.UpArrow)){
			TentarMaior();
		}
		else if(Input.GetKeyDown(KeyCode.DownArrow)){
			TentarMenor();
		}
		else if(Input.GetKeyDown(KeyCode.Return)){
			Acertou();
		}
	}

	private void InitGame() {
		max = startMax;
		min = startMin;

		numTentativas = (int) Math.Log(max - min, 2);
		
		ProximaTentativa();
	}

	public void TentarMenor() {
		max = tentativa;
		ProximaTentativa();
	}

	public void TentarMaior() {
		min = tentativa;
		ProximaTentativa();
	}
	public void Acertou() {
		InitGame();
	}

	private void ProximaTentativa(){
		numTentativas--;

		if(numTentativas < 0){
			levelManager.LoadSceneByName("Derrota");
			return;
		}

		tentativa = (min + max) / 2;

		tentativasText.text = "Ainda me restam " + numTentativas + " tentativas...";
		gameText.text = "Hm... Seu número é " + tentativa + " né?!";
	}
}
