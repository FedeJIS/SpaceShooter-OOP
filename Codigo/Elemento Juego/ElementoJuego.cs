using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class ElementoJuego : MonoBehaviour {

	protected int daño;
	protected int vida;
	
	public ElementoJuego(int daño, int vida){
		this.daño = daño;
		this.vida = vida;
	}
	public int GetDaño(){return this.daño;}
	public int GetVida(){return this.vida;}
	public void SetDaño(int daño){this.daño = daño;}
	public abstract void SetVida(int vida);
	public abstract void Mover(Vector3 movimiento, Limites lim);
	public abstract void Morir();
	public void RestarVida(int daño){
		vida = vida - daño;
		if(vida <= 0)
			Morir();
	}
}
