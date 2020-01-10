using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreadorVida : CreadorElementos {
	public override void Crear(GameObject g, Vector3 posicionSpawn,Quaternion rotacion){
		GameObject clone = Instantiate((GameObject) g,posicionSpawn,rotacion);
		Vida v= clone.GetComponent<Vida>();
		v.SetVidaOtorgada((int)Random.Range(2,8));
		v.SetNombre("Vida");				
	}
}