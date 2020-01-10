using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limites {
	float minX;
	float maxX;
	float minZ;
	float maxZ;
	public Limites(float minX, float maxX, float minZ, float maxZ){
		this.minX = minX;
		this.maxX = maxX;
		this.minZ = minZ;
		this.maxZ = maxZ;
	}
	public float getMinX(){return minX;}
	public float getMinZ(){return minZ;}
	public float getMaxX(){return maxX;}
	public float getMaxZ(){return maxZ;}
}