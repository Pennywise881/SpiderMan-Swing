using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderManController : SpiderMan
{
	[SerializeField]
	Transform cameraTracker;

	[SerializeField]
	float speed, rotateSpeed;


	private void Update()
	{
		moveVelocity = Vector3.zero;

		horizontalAxis = Input.GetAxisRaw("Horizontal");
		verticalAxis = Input.GetAxisRaw("Vertical");

		if (!isSwinging) moveSpidey();
	}

	private void moveSpidey()
	{
		if (verticalAxis != 0)
		{
			rotateSpidey();
			moveVelocity = cameraTracker.forward * verticalAxis * speed;
		}
		else if (horizontalAxis != 0)
		{
			rotateSpidey();
			moveVelocity = cameraTracker.right * horizontalAxis * speed;
		}
	}

	private void rotateSpidey()
	{
		if (verticalAxis < 0) yRot = cameraTracker.eulerAngles.y - 180;
		else if (verticalAxis > 0) yRot = cameraTracker.eulerAngles.y;
		else if (horizontalAxis < 0) yRot = (Mathf.Atan2(cameraTracker.right.x, cameraTracker.right.z) * Mathf.Rad2Deg) - 180;
		else if (horizontalAxis > 0) yRot = Mathf.Atan2(cameraTracker.right.x, cameraTracker.right.z) * Mathf.Rad2Deg;

		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yRot, 0), rotateSpeed * Time.deltaTime);
	}

	private void FixedUpdate()
	{
		rBody.velocity = moveVelocity + jumpVelocity;
	}
}
