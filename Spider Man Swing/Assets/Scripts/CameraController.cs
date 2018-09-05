using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField]
	Transform spidey, cameraTracker;

	[SerializeField]
	float radius, sensitivity, rotationSmoothTime;

	float pitch, yaw;

	Vector3 rotationSmoothVelocity;
	Vector3 currentRotation;

	private void Update()
	{
		cameraTracker.position = transform.position;
		cameraTracker.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
	}

	private void LateUpdate()
	{
		yaw += Input.GetAxis("Mouse X") * sensitivity;
		pitch -= Input.GetAxis("Mouse Y") * sensitivity;
		pitch = Mathf.Clamp(pitch, -3, 70);

		currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
		transform.eulerAngles = currentRotation;

		transform.position = spidey.position - (transform.forward * radius);
	}
}
