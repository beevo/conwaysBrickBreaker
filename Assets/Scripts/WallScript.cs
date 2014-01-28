using UnityEngine;
using System;

public class WallScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter( Collision col ) {
		foreach (ContactPoint contact in col.contacts) {
			if( contact.thisCollider == collider){
				//this is the paddle's contact point
				float english = contact.point.x - transform.position.x;
				
				contact.otherCollider.rigidbody.AddForce( 300f, 0, 0);
			}
		}
	}

}
