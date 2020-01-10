using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreadorPowerUp : CreadorElementos {
	protected const int MINDUR=20;
	protected const int MAXDUR=31;
	public override void Crear(GameObject g, Vector3 posicionSpawn,Quaternion rotacion){
		    GameObject clone = Instantiate((GameObject) g,posicionSpawn,rotacion);
			PowerUp p  = clone.GetComponent<PowerUp>();
			p.SetDuracion(Random.Range(MINDUR,MAXDUR));
			int tipoPowerUp = Random.Range(0,3);
			p.SetBeneficio(tipoPowerUp);
			p.SetNombre(tipoPowerUp);
	}
}
