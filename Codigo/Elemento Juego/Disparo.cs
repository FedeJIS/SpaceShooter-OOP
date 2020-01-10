using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Disparo: MonoBehaviour {
	//MOTOR UNITY
	private Rigidbody rig;
	//ATRIBUTOS
	protected int daño;
	private const float VELOCIDAD = 20;
	//METODOS
	public void SetDaño(int daño){this.daño = daño;}
	public int GetDaño(){return this.daño;}
	public void CausarDaño(GameObject other){
		//LE CAUSO MI DAÑO A LA NAVE PASADA POR PARAMETRO
		Nave n = other.GetComponent<Nave>();
		if(!n.GetInmunidad()){
			n.RestarVida(this.daño);
			n.Explotar();
		}
		
	}
	public void OnTriggerEnter(Collider other) {
		//VERIFICO QUE LA COLISION DE LOS DISPAROS SEA CON NAVES (ENEMIGAS O LA DEL JUGADOR)
		if( (this.CompareTag("DisparoJugador") && other.CompareTag("Enemigo")) ||
			(this.CompareTag("DisparoEnemigo") && other.CompareTag("Jugador")) ){
			CausarDaño(other.gameObject);
			Destroy(this.gameObject);
		}
	}
	void Awake(){
		rig = GetComponent<Rigidbody>();
	}
	void Start () {
		rig.velocity = transform.forward * VELOCIDAD;
	}
}