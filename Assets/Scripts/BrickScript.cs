using UnityEngine;
using System.Collections;


struct Point
{
	public float x, y;
}


public class BrickScript : MonoBehaviour {
	static Vector3[,] lifeArray = new Vector3[16,19];
	static int numBricks = 0;
	public int pointValue = 1;
	// Use this for initialization
	void Start () {
		numBricks++;
		lifeArray[((int)gameObject.transform.position.x + 9), (9 - (int)gameObject.transform.position.y)] = new Vector3(transform.position.x,transform.position.y,transform.position.z);
		Debug.Log (((int)gameObject.transform.position.x + 9) + "," + (9 - (int)gameObject.transform.position.y));
		Debug.Log (lifeArray[((int)gameObject.transform.position.x + 9), (9 - (int)gameObject.transform.position.y)]);
		Debug.Log (lifeArray[0,4]); 
	}
	
	// Update is called once per frame
	void Update () {

	}

	//returns the number of neighbors given a coordinate in the lifeArray
	private int getNeighbors(int x, int y) {
		return 1;
	}


	void OnCollisionEnter( Collision col ) {
		Destroy( gameObject );
		GameObject.Find ("paddle").GetComponent<PaddleScript> ().AddPoint (1);
		numBricks--;
		Debug.Log (numBricks);
		GameObject.FindGameObjectsWithTag ("Brick");
		if (numBricks <= 0) {
			Debug.Log("NO MORE BRICKS!");
			//	Application.LoadLevel("scene 2");
		}

	}
}
