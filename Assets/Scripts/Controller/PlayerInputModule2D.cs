using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Module for player controller input when using a PlatformController2D. Uses standart Horizontal and Vertical input axis as well as Jump button.
/// </summary>
[RequireComponent (typeof(PlatformerController2D))]
public class PlayerInputModule2D : MonoBehaviour
{
	PlatformerController2D controller;

	void Start ()
	{
		controller = GetComponent<PlatformerController2D> ();
	}

	void FixedUpdate ()
	{
		Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		if (input.magnitude > 1) {
			input.Normalize ();
		}
		controller.input = input;
		controller.inputJump = Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.W);
		controller.inputShoot = Input.GetKeyDown (KeyCode.LeftShift);
	}
}
