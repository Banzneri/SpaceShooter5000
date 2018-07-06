using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour {
	[SerializeField] private Color _blinkColor;
	[SerializeField] private float _blinkRate;
 	[SerializeField] private Color _originalColor;
	
	private Material _material;

	void Start () {
		_material = GetComponent<Renderer>().material;
		StartCoroutine(DoBlinking());
	}

	private IEnumerator DoBlinking()
	{
		while (true)
		{
			_material.SetColor("_Color", _blinkColor);
			yield return new WaitForSeconds(_blinkRate);
			_material.SetColor("_Color", _originalColor);
			yield return new WaitForSeconds(_blinkRate);
		}
	}
}
