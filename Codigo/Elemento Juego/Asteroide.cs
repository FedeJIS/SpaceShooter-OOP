using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Asteroide : ElementoJuego {

	//ATRIBUTOS

	//MOTOR UNITY
	private Rigidbody rig;
	private Object explosion;
	protected AudioSource sonido;

	//OBJETOS
	float velocidadMovimiento;
	
	
	//METODOS
	
	public Asteroide(int daño, int vida, float velocidadMovimiento):base(daño,vida){
		this.velocidadMovimiento = velocidadMovimiento;}
	
	public float GetVelocidad(){ return this.velocidadMovimiento;}
	public void SetVelocidad(float velocidad){ velocidadMovimiento = velocidad;}

	public void CausarDaño(GameObject other){
		//Le causo mi daño a una nave pasada x parametro
		Nave n = other.GetComponent<Nave>();
		if(!n.GetInmunidad())
			n.RestarVida(this.daño);
    }
    public override void Morir(){
		Explotar();
		Destroy(this.gameObject);
    }
	
	protected void Explotar(){
		sonido.Play();
		Instantiate(explosion, transform.position, transform.rotation);
	}
    public override void Mover(Vector3 movimiento, Limites lim){
		rig.velocity = movimiento * velocidadMovimiento ;
	}
	public override void SetVida(int vida){this.vida = vida;}

	void OnTriggerEnter(Collider other){
		if(other.CompareTag("Jugador")){
			CausarDaño(other.gameObject);
			Morir();		
		}
		else if(other.CompareTag("DisparoJugador")){
			Disparo d = other.gameObject.GetComponent<Disparo>();
			RestarVida(d.GetDaño());
			Explotar();
			Destroy(other.gameObject);
		}
	}

	//METODOS DE UNITY 

    void Awake (){ 
		rig = GetComponent<Rigidbody>();
		explosion = Resources.Load("Prefabs/VFX/Explosiones/explosion_Asteroide", typeof (GameObject));
		//AssetDatabase.LoadAssetAtPath("Assets/Prefabs/VFX/Explosiones/explosion_Asteroide.prefab", typeof(GameObject));
		sonido = GetComponent<AudioSource>();
	
	 }
}
