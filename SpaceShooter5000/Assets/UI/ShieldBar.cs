using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour {
	[SerializeField] private GameObject _barPanel;
	
	private float _maxShield;
	private Slider _shieldBarSlider;

	public void Init()
	{
		_shieldBarSlider = GetComponent<Slider>();
	}

	public void SetBarValue(float value)
	{
		_shieldBarSlider.value = value;
	}
}
