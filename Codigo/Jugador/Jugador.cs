using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class Jugador : MonoBehaviour {
	//ATRIBUTOS 
	protected float puntuacion; //MI PUNTUACION ACTUAL
	FileManager f;
	Ranking r;

	//MOTOR UNITY
	protected GameObject naveReferenciada; //LA NAVE QUE ESTOY USANDO
	protected Nave naveDebug;
	protected string pathNave; //LA RUTA DEL PREFAB A INSTANCIAR	
	public Text txtpuntuacion;
	public Text txtpuntuacionfinal;
	public GameObject panelFinal;
	protected GameObject audioJuego;
	protected ReproductorMusicaEscenario musicaJuego;
	bool finalizado = false;
	const int FACTORPUNTOS = 100;
	public Text[] txtDebug;

	private void Awake () {
		 f= ScriptableObject.CreateInstance<FileManager>();
		 r= GetComponent<Ranking>();
		 r.SetEntradas(5);
		 pathNave = f.ReadSpecificString(Application.dataPath+"/Resources/PrefabsNaves.txt",0);
		 panelFinal = GameObject.Find("PanelFinJuego");
		 panelFinal.SetActive(false);
		 audioJuego = GameObject.Find("AudioJuego");
		 musicaJuego = audioJuego.GetComponent<ReproductorMusicaEscenario>();
		 naveReferenciada = Instantiate(Resources.Load(pathNave) as GameObject, new Vector3(0,0,0), Quaternion.identity);
		 naveDebug = naveReferenciada.GetComponent<Nave>();	
	
	}
	public void CalcularPuntuacion(){
		//CALCULO LA PUNTUACION EN EL JUEGO
		puntuacion += Time.deltaTime*FACTORPUNTOS;
		txtpuntuacion.text = "Puntuación: "+((int)puntuacion).ToString();
	}
	private void Update() {
		if(!finalizado) ComprobarEstado();
		//DEBUG
		txtDebug[0].text = "VIDA: "+naveDebug.GetVida();
		txtDebug[1].text = "ESCUDO: "+naveDebug.GetInmunidad();
		txtDebug[2].text = "VELOCIDAD: "+naveDebug.GetVelocidadDisparo();
		txtDebug[3].text = "DAÑO: "+naveDebug.GetDaño();


	}
	private void ComprobarEstado(){
			if(naveReferenciada != null)
				CalcularPuntuacion();
			else{
				finalizado = true;
				JuegoFinalizado();
				panelFinal.SetActive(true);
				string aux= ((int)puntuacion).ToString();
				txtpuntuacionfinal.text = aux;
				r.VerificarPuntuacion((int)puntuacion);
				} 
		
	}
	private void JuegoFinalizado(){
		if(finalizado) musicaJuego.FinJuego();
	}
	
	
}