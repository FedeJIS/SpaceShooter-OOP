using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Threading.Tasks;


public class NombreArcade : MonoBehaviour {
    StringBuilder nombre = new StringBuilder("");
	private string alfabeto = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
	protected Ranking r;
	public Text[] textoNombre;

	IEnumerator ObtenerTecla(){
		int posicion = 0;
		int i = 0;
	
		do{
			textoNombre[posicion].color = new Color32(207, 203, 40, 255);
			if(Input.GetKey(KeyCode.UpArrow))
			{
				yield return new WaitForSeconds(0.1f);
				i++;
				if(i > alfabeto.Length-1)
					i = 0;
				textoNombre[posicion].text = alfabeto[i].ToString();
			}
			else if (Input.GetKey(KeyCode.DownArrow))
			{
				yield return new WaitForSeconds(0.1f);
				i--;
				if(i < 0)
					i = alfabeto.Length-1;
				textoNombre[posicion].text = alfabeto[i].ToString();
			}
			else if (Input.GetKey(KeyCode.Space)){
				textoNombre[posicion].color = new Color32(255, 255, 255, 255);
				this.nombre.Insert(posicion, textoNombre[posicion].text);
				posicion++;
				i = 0;
			}
		yield return new WaitForSeconds(0.1f);
		} while (posicion < 3);
		yield break;
	}
	public async Task GetNombre(){
		 await ObtenerTecla();
		 r.SetNombre(nombre.ToString());
	}

	void Awake(){
		r = GetComponent<Ranking>();
	}

}

