using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class ReproductorMusicaEscenario : ReproductorMusica {

	public void FinJuego()
	{
		cancion.Stop();
		cancion.clip = canciones[canciones.Length-1];
		cancion.PlayOneShot(cancion.clip);
	}

	void Awake(){
		cancion = GetComponent<AudioSource>();
	}

	void Start () {
		Reproducir();
	}
}
