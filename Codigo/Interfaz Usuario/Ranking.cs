using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.UI;
using System.Text;

public class Ranking : MonoBehaviour {
	FileManager f;
    int entradas;
    string path;
    public GameObject recordTxt;
    protected NombreArcade nombreJugador;
    string nombre="";

    private void Awake(){
        f= ScriptableObject.CreateInstance<FileManager>();
        recordTxt = GameObject.Find("Record");
		recordTxt.SetActive(false);
        nombreJugador = GetComponent<NombreArcade>();
        path= Application.dataPath+"/Resources/Record.txt";}

    public async void VerificarPuntuacion(int puntos){
       string[] records = f.ReadAll(path); //leo todos los records de la forma "AAA 0..." 
       int pos=0; int record_int; 
       while(pos < entradas){
           int.TryParse(records[pos].Substring(4,records[pos].Length-4),out record_int); 
           //me quedo con la puntuacion en formato int que se encuentra en record[pos]
           if (puntos > record_int){ //me fijo si mi puntuacion actual es mayor a la puntuacion archivada
                await NuevoRecord();
               string puntuacion = nombre + " " + ((int)puntos).ToString();
               f.WriteSpecificString(path,puntuacion,pos);
               for (int i=pos; i< entradas-1; i++){
                   f.WriteSpecificString(path,records[i],i+1);
                } 
               break;          
            }else{
               pos++;
            }
        }
    }
    public async Task NuevoRecord(){
        recordTxt.SetActive(true); 
        await nombreJugador.GetNombre();
    }
    public void SetEntradas(int e){this.entradas= e;}
    public void SetNombre(string n){this.nombre= n;}

  
    }	
