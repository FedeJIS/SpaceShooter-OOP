using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CreadorElementos: ScriptableObject{
	public abstract void Crear( GameObject g , Vector3 posicionSpawn, Quaternion rotacion);
}
