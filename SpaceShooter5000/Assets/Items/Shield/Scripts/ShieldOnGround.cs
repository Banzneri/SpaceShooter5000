using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldOnGround : MonoBehaviour, IItem {
	[SerializeField] private Color _originalColor;
	[SerializeField] private GameObject _shieldPrefab;

	private Material _material;
	private float _colorFadeSpeed = 1f;
	private Player _player;

    void Start () {
		_material = GetComponent<Renderer>().material;
		_originalColor = _material.color;
		_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	
	void Update () {
		float value = _material.GetFloat("_RimEffect");
		value = Mathf.Sin(Time.time * 5f);
		_material.SetFloat("_RimEffect", value);
	}

	public void Use()
    {
        if (_player.CurrentShield != null)
		{
			Destroy(gameObject, 0);
			return;
		}
		GameObject go = Instantiate(_shieldPrefab, _player.transform.position, transform.rotation) as GameObject;
		_player.CurrentShield = go.GetComponent<ShieldActive>();
		go.transform.parent = _player.transform;
		Destroy(gameObject, 0);
    }
}
