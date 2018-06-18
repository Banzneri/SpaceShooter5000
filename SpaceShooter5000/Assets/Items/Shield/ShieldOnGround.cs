using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldOnGround : MonoBehaviour {
	[SerializeField] private Color _originalColor;

	private Material _material;
	private float _colorFadeSpeed = 1f;

	void Start () {
		_material = GetComponent<Renderer>().material;
		_originalColor = _material.color;
	}
	
	void Update () {
		float value = _material.GetFloat("_RimEffect");
		Debug.Log(value);
		value = Mathf.Sin(Time.time * 5f);
		_material.SetFloat("_RimEffect", value);
	}
}
