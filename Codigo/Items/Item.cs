using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour {
	//MOTOR UNITY
	protected Rigidbody rig;
	protected AudioSource sonido;
	//ATRIBUTOS
	protected const float VELOCIDAD = 2;
	protected string nombre;
	
	//METODOS
	public string GetNombre(){return nombre;}
	
	protected IEnumerator Morir(){
		sonido.Play();
		yield return new WaitForSeconds(0.75f);
		Destroy(this.gameObject);
		yield break;
	}

}