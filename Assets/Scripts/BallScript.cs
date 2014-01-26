using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//+ f goes up, - f goes down
		rigidbody.AddForce (0, 300f, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
