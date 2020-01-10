using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Nave : ElementoJuego {
	//MOTOR UNITY
	protected Rigidbody rig;
	public GameObject explosion;
	public GameObject disparo; 
	public Transform posicionSpawnCI;
	public Transform posicionSpawnCD;
	protected AudioSource sonido;
	//ATRIBUTOS
	protected bool inmunidad; 
	public float tasaDisparo;
	float proxDisparo = 0;
	protected const float VELOCIDAD = 6;
	const int MAXVIDA = 12;

    public Nave(int daño, int vida, bool inmunidad, float tasaDisparo) : base(daño,vida){
		this.inmunidad = inmunidad;
		this.tasaDisparo = tasaDisparo;
	}

    public override void Morir(){
		Explotar();
	    Destroy(this.gameObject);
    }

    public override void Mover(Vector3 movimiento, Limites lim){
		const float ANGULOZ = 5;
	    rig.velocity = movimiento * VELOCIDAD;
		rig.position =new Vector3(Mathf.Clamp(rig.position.x, lim.getMinX(), lim.getMaxX()),0f,
		 (Mathf.Clamp(rig.position.z, lim.getMinZ(), lim.getMaxZ())));
		rig.rotation = Quaternion.Euler(0f, rig.rotation.y, rig.velocity.x*-ANGULOZ);
    }

	public float GetVelocidadDisparo()
	{return this.tasaDisparo;}
	
	public void SetVelocidadDisparo(float velocidadDisparo)
	{this.tasaDisparo = velocidadDisparo;}

	public void Disparar(){
	//GENERO LAS INSTANCIAS DE DISPARO DE LOS DOS CAÑONES
		if(Time.time > proxDisparo){
			proxDisparo = Time.time + tasaDisparo;
			if(posicionSpawnCI != null){
				GameObject cloneI = Instantiate(disparo,posicionSpawnCI.position,posicionSpawnCI.rotation);
				Disparo di = cloneI.GetComponent<Disparo>();
				di.SetDaño(this.daño);
			}
			if(posicionSpawnCD != null){
				GameObject cloneD = Instantiate(disparo,posicionSpawnCD.position,posicionSpawnCD.rotation);
				Disparo dd = cloneD.GetComponent<Disparo>();
				dd.SetDaño(this.daño);
			}
			sonido.Play();
		}
	}

	public bool GetInmunidad()
	{return this.inmunidad;}

	public void SetInmunidad(bool inmunidad)
	{this.inmunidad = inmunidad;}

	public override void SetVida(int vida){
		if(vida > MAXVIDA)
			this.vida = MAXVIDA;
		else
			this.vida = vida;
	}


	IEnumerator DesactivarUp(PowerUp p){
		//CUANDO TERMINA LA DURACION DEL BENEFICIO SE DESACTIVA
		yield return new WaitForSeconds(p.GetDuracion());
		p.RestaurarBeneficio(this);
		yield break;
		}
	
	private void OnTriggerEnter(Collider other) {
		if(this.CompareTag("Jugador") && other.CompareTag("PowerUp")){
			PowerUp p = other.GetComponent<PowerUp>();
			StartCoroutine(DesactivarUp(p));
		}

		if((this.CompareTag("Jugador") && other.CompareTag("Enemigo"))||
		this.CompareTag("Enemigo") && other.CompareTag("Jugador"))
		{
			Explotar();
		}
		
	}

	public void Explotar(){
		Instantiate(explosion, transform.position, transform.rotation);
	}
	void Awake(){
		rig = GetComponent<Rigidbody>(); 
		sonido = GetComponent<AudioSource>();
		
	}

}