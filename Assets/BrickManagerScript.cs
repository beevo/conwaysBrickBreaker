using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BrickManagerScript : MonoBehaviour {

	static int[,] lifeArray = new int[16,19]; 

	//list of Vectors of bricks to destroy
	List<Vector3> destroyBricks = new List<Vector3>();
	
	//list of Vectors of bricks to create
	List<Vector3> createBricks = new List<Vector3>();

	int getNumNeighbors(int x, int y){
		int num = 0;
		//if the slides are being looked at, return 0 for simplicity sake
		if (x == 0 || y == 0 || x == 15 || y == 18)
			return 0;
		for (int i = x-1; i <= x+1; i++) {
			for(int j = y-1; j <= y+1; j++){
				if(i == x && j == y) continue;
				if(lifeArray[i,j] == 1){
					num++;
				}
			}
		}
		return num;
	}
	// Use this for initialization
	void Start () {
		GameObject[] bricks = GameObject.FindGameObjectsWithTag ("Brick");

		foreach(GameObject brick in bricks){
			lifeArray[Mathf.Abs(9-(int)brick.transform.position.y), Mathf.Abs(9+(int)brick.transform.position.x)] = 1;
			Debug.Log("already here: "+brick.transform.position);
		}

		string print = "";
		string kill = "";
		string create = "";
		for (int i = 0; i < lifeArray.GetLength(0); i++)
		{
			string row = "";
			for (int j = 0; j < lifeArray.GetLength(1); j++)
			{	//Debug.Log(i + "," + j);6
				int neighbors = getNumNeighbors(i,j);
				//Debug.Log("neighbors of ("+i+","+j+"): "+neighbors);
				row += lifeArray[i,j];
				if(neighbors == 3){
					createBricks.Add(new Vector3(9-i,9+j,0));
					Debug.Log("add new Vector: " + new Vector3(j-9,(i-9)*(-1),0)); 
					create += "("+i+","+j+") ";
				}else if(neighbors < 2 || neighbors > 3){
					if(lifeArray[i,j] == 1)
						destroyBricks.Add(new Vector3(9-i,9+j,0));
						kill += "("+i+","+j+") ";
				}
			}
			print += row + "\n"; 
		}

		Debug.Log (print);
		Debug.Log ("kill: "+kill);
		Debug.Log ("create: "+create);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
