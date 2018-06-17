using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour {
	[SerializeField] private float _life;
	[SerializeField] private EnemySounds _sound;

	private Renderer _renderer;
	private Color _originalColor;

	private void Start() {
		_renderer = GetComponent<Renderer>();
		_originalColor = _renderer.material.color;
	}

	private void OnTriggerEnter(Collider other) {
		Debug.Log("Collision");
		if (other.tag == "Bullet")
		{
			Debug.Log("HitBullet");
			_life -= other.gameObject.GetComponent<Bullet>().Damage;
			Destroy(other.gameObject);
			if (_life < 0)
			{
				_sound.PlayDestructionSound();
				Destroy(this.gameObject);
			}
			StartCoroutine(Blink());
		}
	}

	private IEnumerator Blink()
	{
		_renderer.material.color = Color.red;
		yield return new WaitForSeconds(0.05f);
		_renderer.material.color = _originalColor;
	}
}
