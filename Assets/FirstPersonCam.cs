using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCam : MonoBehaviour
{
	public Transform playerCam;
	public Vector2 Sensitivity;

	private Vector2 XYRotation;

    private void Start()
    {
		Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
	{
		Cursor.visible = true;

		Vector2 MouseInput = new Vector2
		{
			x = Input.GetAxis("Mouse X"),
			y = Input.GetAxis("Mouse Y")
		};

		XYRotation.x -= MouseInput.y * Sensitivity.y;
		XYRotation.y += MouseInput.x * Sensitivity.x;

		XYRotation.x = Mathf.Clamp(XYRotation.x, -88f, 88f);

		transform.eulerAngles = new Vector3(0f, XYRotation.y, 0f);
		playerCam.localEulerAngles = new Vector3(XYRotation.x, 0f, 0f);
	}
}
