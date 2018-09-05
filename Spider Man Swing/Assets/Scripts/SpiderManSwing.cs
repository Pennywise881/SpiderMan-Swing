using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderManSwing : SpiderMan
{
	[SerializeField]
	GameObject swingArea;

	[SerializeField]
	Transform bob, webPoint;

	int awayDistance;

	LineRenderer lineRenderer;

	private void Awake()
	{
		lineRenderer = GetComponent<LineRenderer>();
	}

	private void Update()
	{
		if (!isGrounded && !isSwinging && /*Input.GetKeyDown(KeyCode.LeftShift)*/ Input.GetMouseButton(0))
		{
			isSwinging = true;
			swingArea.transform.rotation = Quaternion.Euler(new Vector3(0, transform.eulerAngles.y + 90, 0));
			swingArea.SetActive(true);
			lineRenderer.enabled = true;
		}

		if (isSwinging)
		{
			transform.position = bob.position;
			lineRenderer.SetPosition(0, webPoint.position);
			lineRenderer.SetPosition(1, swingArea.transform.position);

			if (Input.GetKeyDown("space"))
			{
				isSwinging = false;
				swingArea.SetActive(false);
				lineRenderer.enabled = false;
			}
		}
	}
}
