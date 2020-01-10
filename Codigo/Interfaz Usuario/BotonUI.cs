using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Text;

public class BotonUI: MonoBehaviour {
	public int escenaSiguiente;
	protected AudioSource sonido;
	protected Text texto;
	void Awake(){
		sonido = GetComponent<AudioSource>();
		texto = GetComponent<Text>();
	}
	
	public void Comenzar(){
		StartCoroutine(CambiarEscena());
	}
	IEnumerator CambiarEscena(){ 
		ReproducirAudio();
		yield return new WaitForSeconds(0.25f);
		SceneManager.LoadScene(escenaSiguiente);
		}

	public void ReproducirAudio(){
		sonido.PlayOneShot(sonido.clip);
	}

	public void Entrar(){
		texto.color = new Color32(207, 203, 40, 255);
	}

	public void Salir() {
		texto.color = new Color32(255, 255, 255, 255);
	}
	
	
}
