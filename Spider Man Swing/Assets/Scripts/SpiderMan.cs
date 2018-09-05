using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpiderMan : MonoBehaviour
{
	protected Vector3 moveVelocity;
	protected static Vector3 jumpVelocity;
	protected Vector3 startingPosition;

	protected Rigidbody rBody;

	protected float yRot, horizontalAxis, verticalAxis;

	protected static bool isGrounded, isSwinging;

	private void Awake()
	{
		isGrounded = true;
		startingPosition = transform.position;
		rBody = GetComponent<Rigidbody>();
	}
}
