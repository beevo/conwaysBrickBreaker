using UnityEngine;
using System.Collections;

public class PaddleScript : MonoBehaviour {

	public float paddleSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//	if the input (in this case your arrow key) is left ( < 0)
		//	then move the paddle to the left
		//	if( Input.GetAxis( "Horizontal") < 0 ){
		//		Debug.Log("going left");
		//		//move the paddle to the left
		//		//-10f means to the left, you multiply it by deltaTime
		//		//so it responds uniformly accross computer speeds.
		//		transform.Translate(-10f * Time.deltaTime, 0, 0);
		//	}
		//	same thing but to the right
		//	if( Input.GetAxis( "Horizontal") > 0 ){
		//		Debug.Log("going RIGHT");
		//		transform.Translate(10f * Time.deltaTime, 0, 0);
		//	}

		//does everything the above does in one line.
		transform.Translate(paddleSpeed * Time.deltaTime * Input.GetAxis( "Horizontal"), 0, 0);

		//Debug.log() to get message to console!!
	}
	void OnCollisionEnter( Collision col ) {
		foreach (ContactPoint contact in col.contacts) {
			if( contact.thisCollider == collider){
				//this is the paddle's contact point
				float english = contact.point.x - transform.position.x;

				contact.otherCollider.rigidbody.AddForce( 300f * english, 0, 0);
			}
		}
	}
}
