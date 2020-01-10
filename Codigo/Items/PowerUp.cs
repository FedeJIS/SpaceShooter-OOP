using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : Item {
	//ATRIBUTOS
	protected int duracion = 5;
	protected beneficio miBeneficio = beneficio.DAÑO;
	protected enum beneficio{DAÑO = 0,VELOCIDAD = 1,ESCUDO = 2}

	//METODOS
	public int GetDuracion(){return this.duracion;}
	public void SetDuracion(int d){this.duracion = d;}
	public void SetNombre(int n){
		beneficio b = (beneficio)n;
		this.nombre = b.ToString();
	}
	public void SetBeneficio(int b){
		miBeneficio = (beneficio)b;
	}
	public void EjecutarBeneficio(Nave j){
		switch (miBeneficio){
			case (beneficio)0: //DAÑO
				int daño = j.GetDaño()*2;
				j.SetDaño(daño);
				break;
			case (beneficio)1: //VELOCIDAD
				float vel = j.GetVelocidadDisparo()/2; //como es tasa se divide 
				j.SetVelocidadDisparo(vel);
				break;
			case (beneficio)2: //ESCUDO
				j.SetInmunidad(true);
				break;
		}
	}
	public void RestaurarBeneficio(Nave j){
		switch (miBeneficio){
			case (beneficio)0: //DAÑO
				int daño = j.GetDaño()/2;
				j.SetDaño(daño);
				break;
			case (beneficio)1: //VELOCIDAD
				float vel = j.GetVelocidadDisparo()*2;  
				j.SetVelocidadDisparo(vel);
				break;
			case (beneficio)2: //ESCUDO
				j.SetInmunidad(false);
				break;
		}
	}
	private void OnTriggerEnter (Collider other) {
		//SOLAMENTE VERIFICO SI EL POWERUP COLISIONA CON UN JUGADOR
		if(other.CompareTag("Jugador")){
			Nave j = other.GetComponent<Nave>();
			EjecutarBeneficio(j);
			gameObject.GetComponent<Renderer>().enabled = false;
			StartCoroutine(Morir());
		}
	}

	private void Awake() {
		sonido = GetComponent<AudioSource>();
		
		rig = GetComponent<Rigidbody>(); 
	}
	void Start () { rig.velocity = transform.forward * VELOCIDAD; }
	
	}
