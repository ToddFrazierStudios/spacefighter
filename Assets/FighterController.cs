using UnityEngine;
using System.Collections;

public class FighterController : MonoBehaviour {

	public Rigidbody mainThrust;

	public ParticleSystem leftGun, rightGun;

	public Vector3 foreThrust = new Vector3(0f, 0f, 0.75f);

	public Vector3 aftThrust = new Vector3(0f, 0f, -0.5f);
	
	public float mainPower = 10f;

	public float thrustPower = 5f;

	void Start () {
		Physics.gravity = Vector3.zero;
	}

	void FixedUpdate () {
		Debug.Log(Input.GetAxis ("Horizontal"));
		//Debug.Log(Input.GetAxis ("Vertical"));
		if (Input.GetKey(KeyCode.LeftShift) || Input.GetAxis ("Fire2") != 0) {
			mainThrust.AddRelativeForce(Vector3.forward * mainPower);
		}
		if (Input.GetKey(KeyCode.D)) {
			mainThrust.AddRelativeTorque (Vector3.up * thrustPower);
		}
		if (Input.GetKey(KeyCode.A)) {
			mainThrust.AddRelativeTorque (Vector3.down * thrustPower);
		}
		if (Input.GetAxis ("Horizontal") > .2 || Input.GetAxis ("Horizontal") < -.2 ) {
			mainThrust.AddRelativeTorque (Vector3.up * thrustPower * Input.GetAxis ("Horizontal"));
		}
		if (Input.GetAxis ("Vertical") > .2 || Input.GetAxis ("Vertical") < -.2 ) {
			mainThrust.AddRelativeTorque (Vector3.left * thrustPower * Input.GetAxis ("Vertical"));
		}
		if (Input.GetKey(KeyCode.W)) {
			mainThrust.AddRelativeTorque (Vector3.right * thrustPower);
		}
		if (Input.GetKey(KeyCode.S)) {
			mainThrust.AddRelativeTorque (Vector3.left * thrustPower);
		}
		if (Input.GetKey (KeyCode.Space) || Input.GetAxis("Fire1") != 0) {
			leftGun.Emit(1);
			rightGun.Emit(1);
		}
	}
}
