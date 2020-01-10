using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
public class Selector : MonoBehaviour {

	public string pathNave;
	public string filename;
	protected FileManager f;
	void Awake(){
		f = ScriptableObject.CreateInstance<FileManager>();
	}
	public void SetPath(){
		 string path = Application.dataPath+"/Resources/"+filename+".txt";
		 f.WriteSpecificString(path,pathNave,0);
		 SceneManager.LoadScene(3);
		}
		
	
	}
	//private void OnMouseDown() {setPath();}

