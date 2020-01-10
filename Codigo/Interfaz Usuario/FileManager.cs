using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileManager:ScriptableObject{
    string[] lineas;
    public void WriteSpecificString(string path, string x, int line_to_edit){
            lineas = File.ReadAllLines(path);
            lineas[line_to_edit] = x; 
            File.WriteAllLines(path, lineas);
        }

    public string ReadSpecificString(string path, int pos) {
     string[] lineas = File.ReadAllLines(path);
     return lineas[pos]; 
    }

    public string[] ReadAll(string path) {
        return File.ReadAllLines(path); 
    }

    public void CreateFile(string path, string texto){
        File.WriteAllText(path,texto);
    }
}
