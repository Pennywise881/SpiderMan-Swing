using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SwingArea))]
public class SwingAreaEditor : Editor
{
	SwingArea swingArea;

	private void OnSceneGUI()
	{
		swingArea = target as SwingArea;

		Vector3 right_ArcPoint = swingArea.transform.position + Quaternion.AngleAxis(swingArea.angle, swingArea.transform.forward) * Vector3.down * swingArea.radius;
		Vector3 left_ArcPoint = swingArea.transform.position + Quaternion.AngleAxis(-swingArea.angle, swingArea.transform.forward) * Vector3.down * swingArea.radius;

		Handles.color = Color.green;
		Handles.DrawWireArc(swingArea.transform.position, swingArea.transform.forward, swingArea.transform.up, 360, swingArea.radius);
		Handles.color = Color.black;
		Handles.DrawLine(swingArea.transform.position, left_ArcPoint);
		Handles.color = Color.white;
		Handles.DrawLine(swingArea.transform.position, right_ArcPoint);
	}
}
