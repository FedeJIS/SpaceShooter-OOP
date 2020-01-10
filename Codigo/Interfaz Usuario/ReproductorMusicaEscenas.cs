using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class ReproductorMusicaEscenas : ReproductorMusica {


	public int escenaMax; //La escena en la que debe destruirse este reproductor,.

	void OnSceneLoaded(Scene scene, LoadSceneMode mode){
		if((scene.buildIndex > escenaMax))
			Destroy(this.gameObject);
	}
	
	void Awake(){
		DontDestroyOnLoad(this.gameObject);
		cancion = GetComponent<AudioSource>();
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void Start () {
		Reproducir();
	}

}
