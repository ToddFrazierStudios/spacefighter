using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private MouseLook mouseLook;

	private ZeroGravityMouseLook zGMouseLook;

	private MonoBehaviour fpsController;

	private MonoBehaviour characterMotor;

	private CharacterController characterController;

	private PlayerController playerController;

	// Use this for initialization
	void Start () {
		Screen.showCursor = false;
		rigidbody.isKinematic = true;
		mouseLook = GetComponent<MouseLook> ();
		mouseLook.enabled = true;
		zGMouseLook = GetComponent<ZeroGravityMouseLook>();
		zGMouseLook.enabled = false;
		fpsController = GetComponent<FPSInputController>();
		fpsController.enabled = true;
		characterMotor = GetComponent<CharacterMotor>();
		characterMotor.enabled = true;
		characterController = GetComponent<CharacterController>();
		characterController.enabled = true;
		playerController = GetComponent<PlayerController>();
		playerController.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Gravity Field") {
			switchMode();
		}
	}

	private void switchMode() {
		Debug.Log("turned off");
		rigidbody.isKinematic = false;
		rigidbody.useGravity = false;
		mouseLook.enabled = false;
		zGMouseLook.enabled = true;
		fpsController.enabled = false;
		characterMotor.enabled = false;
		characterController.enabled = false;
		playerController.enabled = true;
	}
}
