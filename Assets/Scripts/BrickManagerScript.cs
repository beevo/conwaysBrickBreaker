using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
public class BrickManagerScript : MonoBehaviour {
	public Transform newBrick;
	static int[,] lifeArray = new int[16,19]; 

	//list of Vectors of bricks to destroy
	public List<int> destroyBricks = new List<int>();
	
	//list of Vectors of bricks to create
	public List<Vector3> createBricks = new List<Vector3>();

	//list of Vectors of current bricks
	public List<Vector3> currentBricks = new List<Vector3>();

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
	void createHiddenBricks(){
		for (int i = -9; i <= 9; i++) {
			for(int j = -6; j <= 9; j++){
				Vector3 position = new Vector3(i,j,0);
				if(currentBricks.Contains(position))
					continue;
				else{
					position.z = 1;
					var go = Instantiate(newBrick, position, transform.rotation);
				}
			}
		}
	}
	public void renderNextGeneration(){
		Debug.Log ("RENDER NEXT GEN");
		GameObject[] bricks = GameObject.FindGameObjectsWithTag("Brick");
		//kill all bricks in destroyBricks Array
		foreach (int i in destroyBricks) {
			Destroy(bricks[i]);		
		}

		//create new bricks in createBricksArray
		foreach (Vector3 position in createBricks) {
			Instantiate(newBrick, position, transform.rotation);		
		}

		//calculate next gen
		calculateNextGeneration ();
	}
	private void calculateNextGeneration(){
		GameObject[] bricks = GameObject.FindGameObjectsWithTag("Brick");
		
		//add all of the current location of the bricks here.
		foreach(GameObject brick in bricks){
			lifeArray[Mathf.Abs(9-(int)brick.transform.position.y), Mathf.Abs(9+(int)brick.transform.position.x)] = 1;
			currentBricks.Add(brick.transform.position);
		}
		
		int[,] temp = new int[16,19];
		string print = "";
		for (int i = 0; i < lifeArray.GetLength(0); i++)
		{	string row = "";
			for (int j = 0; j < lifeArray.GetLength(1); j++)
			{	int neighbors = getNumNeighbors(i,j);
				row += lifeArray[i,j];
				if(neighbors == 3 && lifeArray[i,j] == 0){
					createBricks.Add(new Vector3(j-9,9-i,0));
					//Debug.Log("create Brick at: "+new Vector3(j-9,9-i,0));
					temp[i,j] = 1;
				}else if(neighbors < 2 || neighbors > 3){
					if(lifeArray[i,j] == 1){
						int index = Array.FindIndex(bricks, x => x.transform.position == new Vector3(j-9,9-i,0));
						destroyBricks.Add(index);
						Debug.Log("destroy index here: "+Array.FindIndex(bricks, x => x.transform.position == new Vector3(j-9,9-i,0)));
					}
				}
			}
			print += row + "\n"; 
		}
		lifeArray = temp;
	}

	// Use this for initialization
	void Start () {
		calculateNextGeneration ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
