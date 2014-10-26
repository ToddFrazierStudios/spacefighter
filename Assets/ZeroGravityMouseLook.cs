using UnityEngine;
using System.Collections;

[AddComponentMenu("Zero Gravity Mouse Look")]
public class ZeroGravityMouseLook : MonoBehaviour {
	
	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 5F;
	public float sensitivityY = 5F;
	
	public float minimumX = -360F;
	public float maximumX = 360F;
	
	public float minimumY = -360F;
	public float maximumY = 360F;
	
	void Update ()
	{
		if (axes == RotationAxes.MouseXAndY)
		{
			transform.Rotate(-Input.GetAxis("Mouse Y") * sensitivityY, Input.GetAxis("Mouse X") * sensitivityX, 0);
		}
		else if (axes == RotationAxes.MouseX)
		{
			transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
		}
		else
		{
			transform.Rotate(-Input.GetAxis("Mouse Y") * sensitivityY, 0, 0);
		}
	}
	
	void Start ()
	{
		if (rigidbody)
			rigidbody.freezeRotation = true;
	}
}