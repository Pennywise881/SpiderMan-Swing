using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderManJump : SpiderMan
{
	[SerializeField]
	float jumpHeight, timeToJumpApex, rayDist;
	float gravity;
	float jumpSpeed;

	private void OnDrawGizmos()
	{
		Debug.DrawRay(transform.position, Vector3.down * rayDist, Color.red);
	}

	private void Update()
	{
		if (transform.position.y < -20) transform.position = startingPosition;

		if (!isSwinging) jumpPhysics();
		else jumpVelocity.y = 0;
	}

	public void jumpPhysics()
	{

		if (Physics.Raycast(transform.position, Vector3.down, rayDist, 1 << 9))
		{
			jumpVelocity.y = 0;
			isGrounded = true;
		}
		else
		{
			gravity = -(jumpHeight * 2) / Mathf.Pow(timeToJumpApex, 2);
			jumpVelocity.y += gravity * Time.deltaTime;
		}

		if (Input.GetKeyDown("space") && isGrounded)
		{
			jumpSpeed = Mathf.Abs(gravity) * timeToJumpApex;
			jumpVelocity.y = jumpSpeed;
			isGrounded = false;
		}
	}
}
