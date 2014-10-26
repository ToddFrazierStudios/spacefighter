using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Is the player floating?
	private bool floating = false;

	// How much the player moves
	public float acceleration = 100;
	public float jumpAcceleration = 300;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (floating);
		if (!floating) {
			float move = Input.GetAxis ("Vertical") * acceleration;
			float jump = Input.GetAxis ("Jump") * jumpAcceleration;
			rigidbody.AddRelativeForce (0f, 0f, move + jump);

		}
	}

	void OnCollisionEnter () {
		floating = false;
	}
	
	void OnCollisionExit () {
		floating = true;
	}
}
