using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GeneradorElementos : MonoBehaviour {
	public float tiempoEspera;
	public float tiempoCooldown;
	public int CantElem; 
	int CantPrefabs;
	CreadorCompuesto c; 
	void Start (){
		c =ScriptableObject.CreateInstance<CreadorCompuesto>();
		CantPrefabs = c.GetCantElem();	
		StartCoroutine(Spawnear());
	}	
	IEnumerator Spawnear(){
		while(true){
		yield return new WaitForSeconds(tiempoCooldown);
		for(int i = 0; i<CantElem; i++){ 
			//CANTELEM ES LA CANTIDAD DE ELEMENTOS QUE VOY A SPAWNEAR 
			Vector3 posicionSpawn = new Vector3(Random.Range(-2.95f,2.95f),0f,transform.position.z);
			int pos = Random.Range(0,CantPrefabs);
			//SI MI POS ESTÁ ENTRE 6 Y 9, ES UN POWERUP, ENTONCES LA CALCULO DE NUEVO PARA DISMINUIR LA PROBABILIDAD
			if (pos >= 6 && pos <= 9) {pos = Random.Range(0,CantPrefabs);}
			c.ElegirElem(pos,posicionSpawn, transform.rotation);
			yield return new WaitForSeconds(tiempoEspera);
		}yield return new WaitForSeconds(tiempoEspera);}
	}
}