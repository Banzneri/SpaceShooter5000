using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour {
	[SerializeField] private GameObject _barPanel;
	
	private float _maxShield;
	private Slider _shieldBarSlider;

	private void Start() {
		_shieldBarSlider = GetComponent<Slider>();
	}

	public void SetBarValue(float value)
	{
		_shieldBarSlider.value = value;
	}
}
