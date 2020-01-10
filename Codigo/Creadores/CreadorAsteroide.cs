using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreadorAsteroide : CreadorElementos {
	protected const int DAÑO=3;
	protected const int MINVIDA=2;
	protected const int MAXVIDA=5;
	protected const int MINVEL=2;
	protected const int MAXVEL=6;
	public override void Crear(GameObject g, Vector3 posicionSpawn, Quaternion rotacion){
		GameObject clone = Instantiate((GameObject) g,posicionSpawn,rotacion);
		Asteroide a  = clone.GetComponent<Asteroide>();
			a.SetDaño(DAÑO);
			a.SetVida(Random.Range(MINVIDA,MAXVIDA)); 
			a.SetVelocidad((int)Random.Range(MINVEL,MAXVEL));
			a.Mover(a.transform.forward, null);
		}
}
