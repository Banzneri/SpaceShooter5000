using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{

    public abstract class BaseEnemy : MonoBehaviour
    {

        #region Effect Variables

        // Eplosion Particle Effect
        [SerializeField]
        private GameObject _ExplosionParticleEffect;

        // GameObject containing enemy sounds
        private EnemySounds _SoundStorage;

        #endregion

        #region Health Variables

        // Health
        [SerializeField]
        private int _StartHealth;

        // Current Health of the Enemy
        public int CurrentHealth { get; set; }

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
        void Start()
        {

            // Find EnemySounds GameObject
            _SoundStorage = GameObject.FindGameObjectWithTag("Sounds").GetComponent<EnemySounds>();

            // Find Player GameObject
            _Player = GameObject.FindGameObjectWithTag("Player");

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
                    _SoundStorage.PlayDestructionSound();
                    Instantiate(_ExplosionParticleEffect, transform.position, Quaternion.identity);
                    Destroy(this.gameObject);
                }
            }
        }

    }
}