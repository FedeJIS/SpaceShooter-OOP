using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorEnemigo : MonoBehaviour {
	//MOTOR UNITY
	Vector3 movimiento;
	protected Nave naveEnemigo;
	protected Rigidbody rb;
	//ATRIBUTOS
	Limites lim;

	void Awake(){
		float minX = -2.8f;
		float maxX = 2.8f;
		float minZ = 20f;
		float maxZ = 7f;
		lim = new Limites(minX,maxX,minZ,maxZ);
	}
	void Start(){
		naveEnemigo = GetComponent<Nave>();
		rb = GetComponent<Rigidbody>();
		naveEnemigo.Mover(transform.forward, lim);
	}
	void FixedUpdate(){
		naveEnemigo.Disparar();
	}
}
