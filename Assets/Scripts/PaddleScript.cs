using UnityEngine;
using System.Collections;

public class PaddleScript : MonoBehaviour {
	int lives = 4;

	public float paddleSpeed = 15f;

	public GameObject ballPrefab;

	int score = 0;

	GUIText guiLives;

	public GUISkin scoreboardSkin;

	GameObject attachedBall = null;
	// Use this for initialization
	void Start () {
		guiLives = GameObject.Find("GUILives").GetComponent<GUIText>();
		SpawnBall ();


	}

	public void AddPoint(int value) {
		score += value;
	}

	void OnGUI() {
		GUI.skin = scoreboardSkin;
		GUI.Label ( new Rect(0,10,100,100), "Score: "+ score);	
	}
	public void SpawnBall(){
		if (ballPrefab == null) {
			Debug.Log("Did not add ballPrefab");
			return;
		}
		attachedBall = (GameObject)Instantiate( ballPrefab, transform.position + new Vector3(0,.75f,0), Quaternion.identity);
		lives--;

		GUIText guiLives = GameObject.Find("GUILives").GetComponent<GUIText>();
	//	if(guiLives)
			guiLives.text = "Lives: " + lives;
	}
	// Update is called once per frame
	void Update () {
		//does everything the above does in one line.
		transform.Translate(paddleSpeed * Time.deltaTime * Input.GetAxis( "Horizontal"), 0, 0);

		if (transform.position.x > 7.4) {
			transform.position = new Vector3(7.4f, transform.position.y, transform.position.z);		
		}

		if (transform.position.x < -7.4) {
			transform.position = new Vector3(-7.4f, transform.position.y, transform.position.z);		
		}

		if (attachedBall) {
			Rigidbody ballRidgidBody = attachedBall.rigidbody;
			ballRidgidBody.position = transform.position + new Vector3(0, .75f, 0);
			if(Input.GetButtonDown ("LaunchBall")){
				attachedBall.rigidbody.isKinematic = false;
				attachedBall.rigidbody.AddForce(300f * Input.GetAxis( "Horizontal"),300f,0);
				attachedBall = null;
			}
		}
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
