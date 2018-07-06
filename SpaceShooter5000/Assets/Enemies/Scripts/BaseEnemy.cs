using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{

    #region Effect Variables

    // Eplosion Particle Effect
    [SerializeField]
    private GameObject _ExplosionPrefab;

    // GameObject containing enemy sounds
    private EnemySounds _SoundStorage;

    private rippleSharp _ripple;

    #endregion

    #region Settings

    // Health
    [SerializeField]
    private int _StartHealth;

    // Current Health of the Enemy
    public int CurrentHealth { get; set; }

    // Score value of enemy
    [SerializeField]
    private float _ScoreValue;

    #endregion

    #region Behaviour Variables

    // Player object
    [SerializeField]
    private GameObject _Player;

    public GameObject Player
    {
        get { return _Player; }
    }

    #endregion

    // Use this for initialization
    public void Start()
    {

        // Find EnemySounds GameObject
        _SoundStorage = GameObject.FindGameObjectWithTag("Sounds").GetComponent<EnemySounds>();

        // Find Player GameObject
        _Player = GameObject.FindGameObjectWithTag("Player");

        _ripple = GameObject.FindGameObjectWithTag("RipplePlane").GetComponent<rippleSharp>();;

    }


    private void OnTriggerEnter(Collider other)
    {
        // If hit by bullet, take damage
        if (other.tag == "Bullet")
        {
            CurrentHealth -= (int)(other.gameObject.GetComponent<Bullet>().Damage);
            Destroy(other.gameObject);
            if (CurrentHealth < 0)
            {
                Die();
            }
        }
    }

    public void Die()
    {
        _Player.GetComponent<PlayerScore>().AddScore(_ScoreValue);
        _SoundStorage.PlayDestructionSound();
        Instantiate(_ExplosionPrefab, transform.position, Quaternion.identity);
        _ripple.MakeWave(transform.position);
        Destroy(this.gameObject);
    }

}