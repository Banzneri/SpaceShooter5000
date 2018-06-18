using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {
	
	void Start () {
		
	}
	
	void Update () {
		transform.position += 30f * Time.deltaTime * transform.forward;
	}
}
