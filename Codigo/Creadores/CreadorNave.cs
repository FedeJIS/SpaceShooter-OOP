using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreadorNave : CreadorElementos {
	protected const int DAÑO=2;
	protected const int MINVIDA=3;
	protected const int MAXVIDA=6;
	public override void Crear(GameObject g, Vector3 posicionSpawn,Quaternion rotacion){
			GameObject clone = Instantiate((GameObject) g,posicionSpawn,rotacion);
			Nave n  = clone.GetComponent<Nave>();
			n.SetDaño(DAÑO);
			n.SetVida(Random.Range(MINVIDA,MAXVIDA)); 
			n.SetVelocidadDisparo(Random.Range(0.5f,1f));
	}
}
