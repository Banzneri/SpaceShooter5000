using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySounds : MonoBehaviour {
	[SerializeField] private AudioClip _destructionSound;
	[SerializeField] private AudioClip _shootSound;

	private AudioSource _audio;

	void Start () {
		_audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlayDestructionSound()
	{
		_audio.PlayOneShot(_destructionSound);
	}

	public void PlayShootsound()
	{
		_audio.PlayOneShot(_shootSound);
	}
}
