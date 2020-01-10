using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorJugador : MonoBehaviour {
	// MOTOR UNITY
	Vector3 movimiento;
	protected Nave naveJugador;
	protected Jugador j;
	Limites lim;
	
	//ATRIBUTOS
	protected const int DAÑOINICIAL= 1;
	protected const int VIDAINICIAL= 10;
	protected const float VELOCIDADINICIAL=0.5f;
	void Awake(){
		float minX = -2.8f;
		float maxX = 2.8f;
		float minZ = -1f;
		float maxZ = 6f;
		lim = new Limites(minX,maxX,minZ,maxZ);
		naveJugador = GetComponent<Nave>();
		naveJugador.SetDaño(DAÑOINICIAL);
		naveJugador.SetVida(VIDAINICIAL);
		naveJugador.SetVelocidadDisparo(VELOCIDADINICIAL);
		
	}  

	public void GenerarMovimiento(){
		float movimientoH = Input.GetAxis("Horizontal");
		float movimientoV = Input.GetAxis("Vertical");
		movimiento = new Vector3(movimientoH, 0f, movimientoV);
		naveJugador.Mover(movimiento, lim);
	}
	void FixedUpdate () {
		GenerarMovimiento();
		naveJugador.Disparar();
	}
}