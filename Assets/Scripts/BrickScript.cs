using UnityEngine;
using System.Collections;

public class BrickScript : MonoBehaviour {

	static int numBricks = 0;
	public int pointValue = 1;
	// Use this for initialization
	void Start () {
		numBricks++;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter( Collision col ) {
		Destroy( gameObject );
		GameObject.Find ("paddle").GetComponent<PaddleScript> ().AddPoint (1);
		numBricks--;
		Debug.Log (numBricks);
		GameObject.FindGameObjectsWithTag ("Brick");
		if (numBricks <= 0) {
			Application.LoadLevel("scene 2");
		}

	}
}
