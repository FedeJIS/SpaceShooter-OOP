using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Threading.Tasks;
public class CreadorCompuesto : CreadorElementos {
	//ATRIBUTOS

	CreadorAsteroide a;
	CreadorNave n; 
	CreadorPowerUp p; 
	CreadorVida v; 
	FileManager f;
	protected ArrayList prefabs = new ArrayList();

	public void ElegirElem (int i, Vector3 posicionSpawn,Quaternion rotacion){
		//ELIJO EL GAMEOBJECT A INSTANCIAR DEL ARREGLO EN LA POS i DADA POR PARAMETRO
		GameObject aux = (GameObject) prefabs[i];
		this.Crear(aux,posicionSpawn,rotacion);
	}
	private void CargarElementos(){
		//CARGO LOS PREFABS DESDE EL ARCHIVO CORRESPONDIENTE
		string filepath = Application.dataPath+"/Resources/Prefabs.txt";
		foreach (string path in f.ReadAll(filepath)){
				prefabs.Add(Resources.Load(path) as GameObject);
			}
		
	}
	public int GetCantElem(){return this.prefabs.Count;}
	public override void Crear(GameObject g, Vector3 posicionSpawn,Quaternion rotacion){

		//DADO EL GAMEOBJECT G VERIFICO EL TAG DEL MISMO PARA LLAMAR AL CREADOR
		switch (g.tag) {
			case "Asteroide" : a.Crear(g,posicionSpawn,rotacion);
			break;
			case "Enemigo" : n.Crear(g,posicionSpawn, rotacion);
			break;
			case "PowerUp" : p.Crear(g,posicionSpawn,rotacion);
			break;
			case "Vida" : v.Crear(g,posicionSpawn,rotacion);
			break;
		}
	}
	
	private void Awake(){
		a= ScriptableObject.CreateInstance<CreadorAsteroide>();            
		n =ScriptableObject.CreateInstance<CreadorNave>();
		p =ScriptableObject.CreateInstance<CreadorPowerUp>();
		v =ScriptableObject.CreateInstance<CreadorVida>();
		f = ScriptableObject.CreateInstance<FileManager>();
		CargarElementos();
	}

}