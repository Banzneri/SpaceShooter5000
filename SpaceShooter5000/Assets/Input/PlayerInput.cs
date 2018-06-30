using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

	public static bool DefaultGunDown()
	{
		return Input.GetKeyDown(KeyCode.Mouse0);
	}

	public static bool ExtraGunDown()
	{
		return Input.GetKeyDown(KeyCode.Mouse1);
	}

	public static bool DefaultGunUp()
	{
		return Input.GetKeyUp(KeyCode.Mouse0);
	}

	public static bool ExtraGunUp()
	{
		return Input.GetKeyUp(KeyCode.Mouse1);
	}

	public static Vector2 GetAxis()
	{
		return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
	}
}
