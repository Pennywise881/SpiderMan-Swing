using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingArea : MonoBehaviour
{
	[SerializeField]
	Transform spidey;
	public Transform bob;

	[Range(5, 30)]
	public int radius;

	[Range(10, 180)]
	public float angle;

	[SerializeField]
	float maxSpeed;
	float bobMoveSpeed;
	float moveAngle;
	float arcLength;
	float speedDirection;

	Vector3 right_arcPoint;
	Vector3 left_arcPoint;

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawSphere(transform.position, 0.2f);
	}

	private void OnEnable()
	{
		StartCoroutine(SwingBob());
	}

	IEnumerator SwingBob()
	{
		makeSwingCalculations();

		while (true)
		{
			bobMoveSpeed = Mathf.Lerp(bobMoveSpeed, speedDirection * maxSpeed, Time.deltaTime);
			moveAngle += bobMoveSpeed * Time.deltaTime;

			bob.position = transform.position + Quaternion.AngleAxis(moveAngle, transform.forward) * Vector3.down * radius;

			compareArcLength();

			yield return new WaitForEndOfFrame();
		}
	}

	private void makeSwingCalculations()
	{
		transform.position = new Vector3(spidey.position.x, spidey.position.y + radius, spidey.position.z);

		right_arcPoint = transform.position + Quaternion.AngleAxis(angle, transform.forward) * Vector3.down * radius;
		left_arcPoint = transform.position + Quaternion.AngleAxis(-angle, transform.forward) * Vector3.down * radius;

		bob.position = new Vector3(transform.position.x, transform.position.y - radius, transform.position.z);

		arcLength = (2 * Mathf.PI * radius * angle) / 360;

		moveAngle = 0;
		bobMoveSpeed = 0;
		speedDirection = -1;
	}

	private void compareArcLength()
	{
		float bobAngle = 180 - Vector3.Angle(transform.up, bob.position - transform.position);

		float bobArcLength = (2 * Mathf.PI * radius * bobAngle) / 360;

		if (bobArcLength > arcLength)
		{
			if (Vector3.Distance(bob.position, right_arcPoint) < Vector3.Distance(bob.position, left_arcPoint)) speedDirection = -1;
			else speedDirection = 1;
		}
	}

	private void OnDisable()
	{
		StopCoroutine(SwingBob());
	}
}
