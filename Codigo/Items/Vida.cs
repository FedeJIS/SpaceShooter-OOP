using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : Item {
	//ATRIBUTOS
	protected int vidaOtorgada;

	//METODOS
	public int GetVidaOtorgada(){return this.vidaOtorgada;}
	public void SetVidaOtorgada(int v){this.vidaOtorgada = v;}
	public void SetNombre(string n){nombre = n;}
	private void OnTriggerEnter(Collider other){
		//SOLAMENTE VERIFICO SI COLISIONO CON UN JUGADOR
		if(other.CompareTag("Jugador")){
			Nave j = other.GetComponent<Nave>();
			int vidaJugador = j.GetVida();
			j.SetVida(vidaJugador+vidaOtorgada);
			gameObject.GetComponentInChildren<Renderer>().enabled = false;
			StartCoroutine(Morir());
		}
	}

	private void Awake() {
		sonido = GetComponent<AudioSource>();
		rig = GetComponent<Rigidbody>(); 
	}
	void Start () { rig.velocity = transform.forward * VELOCIDAD; }
}
