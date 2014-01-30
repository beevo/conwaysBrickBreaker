using UnityEngine;
using System.Collections;
using System.Collections;
using System.Collections.Generic;

public class BrickScript : MonoBehaviour {
	static Vector3[,] lifeArray = new Vector3[16,19];
	static int numBricks = 0;
	public int pointValue = 1;
	// Use this for initialization
	void Start () {
		numBricks++;
	}
	
	// Update is called once per frame
	void Update () {

	}

	//returns the number of neighbors given a coordinate in the lifeArray
	int getNeighbors(int x, int y) {
		return 1;
	}

	void OnCollisionEnter( Collision col ) {
		GameObject.Find("BrickManager").GetComponent<BrickManagerScript>().renderNextGeneration();
	}
}
