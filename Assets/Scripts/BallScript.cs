using UnityEngine;
using System.Collections;
using System;
public class BallScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//+ f goes up, - f goes down
		//rigidbody.AddForce (0, 300f, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter( Collision col ) {
		foreach (ContactPoint contact in col.contacts) {
			if((float)(Math.Round((double)(contact.point.y),2)) == (float)Math.Round((double)(transform.position.y),2)){
				Debug.Log("ALL IS LOST!");
				contact.thisCollider.rigidbody.AddForce(0, -300f,0);
				//Debug.Log(contact.thisCollider.rigidbody.AddForce(300f, 0, 0));
				//Debug.Log(contact.ToString);
				//contact.rigidbody.AddForce( 300f , 0, 0);
			//	contact.thisCollider.rigidbody.AddForce(300f, 0, 0);
			}
			/**
			if( contact.thisCollider == collider){
				//this is the paddle's contact point
				float english = contact.point.x - transform.position.x;
				Debug.Log (english); 

			}
			*/
		}

	}

	public void Die() {
		Destroy(gameObject);
		GameObject paddleObject = GameObject.Find("paddle");
		PaddleScript paddleScript = paddleObject.GetComponent<PaddleScript>();
		paddleScript.SpawnBall();

	}
}