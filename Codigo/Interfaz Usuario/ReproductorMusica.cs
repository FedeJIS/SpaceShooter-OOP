using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ReproductorMusica : MonoBehaviour {

	public AudioClip[] canciones;
    protected AudioSource cancion;

	public void Reproducir()
    {
		if(canciones.Length>1){
			int cancionRandom = Random.Range (0, canciones.Length-1);
			cancion.clip = canciones[cancionRandom];
		}else{
			cancion.clip = canciones[0];
		}
	cancion.Play();
    }

	
}
