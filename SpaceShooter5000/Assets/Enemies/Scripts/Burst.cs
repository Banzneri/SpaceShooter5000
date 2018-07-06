using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{

    public class Burst : MonoBehaviour
    {

        #region Settings

        // Enemy type to pe spawned
        [SerializeField]
        private GameObject _EnemyType;

        // Amount of iterations
        [SerializeField]
        private int _Iterations;

        // Rate of iterations
        [SerializeField]
        private float _Rate;

        // Selected burst type
        [SerializeField]
        private BurstType _Type;

        // SpawnPoint
        [SerializeField]
        private SpawnPoint _SpawnPoint;

        // Link next burst to this one
        [SerializeField]
        private bool _LinkBurst;


        #endregion

        #region Private Variables

        // Different types of spawning
        private enum BurstType { SINGLE_CHANNEL, TRIPLE_CHANNEL}

        // When the next iteration takes place
        private float _SpawnTimer;

        // how many iterations left
        private int _IterationsLeft;
        

        #endregion

        // Use this for initialization
        void Start()
        {
            _IterationsLeft = _Iterations;
            _SpawnTimer = _Rate;
        }


        /*
         * Called from parent Wave when it's time to burst
         * Returns false when everything is spawned
         */
        public bool Bursting()
        {

            // if iterations left, update spawn timer
            if(_IterationsLeft > 0)
            {
                _SpawnTimer -= Time.deltaTime;

                // if spawn timer reaches zero, spawn enemies
                if(_SpawnTimer <= 0)
                {
                    Spawn();
                    _SpawnTimer = _Rate;
                    _IterationsLeft--;
                }

                // If no iterations left, this burst is completed
                return _IterationsLeft > 0;

            } else
            {
                return false;
            }

           
        }

        // Spawns enemies using selected BurstType
        private void Spawn()
        {
            if(_EnemyType == null)
            {
                return;
            }

            switch (_Type)
            {
                case BurstType.SINGLE_CHANNEL:
                    Instantiate(_EnemyType, _SpawnPoint.MiddleLoc.position, _SpawnPoint.MiddleLoc.rotation);
                    break;
                case BurstType.TRIPLE_CHANNEL:
                    Instantiate(_EnemyType, _SpawnPoint.LeftLoc.position, _SpawnPoint.LeftLoc.rotation);
                    Instantiate(_EnemyType, _SpawnPoint.MiddleLoc.position, _SpawnPoint.MiddleLoc.rotation);
                    Instantiate(_EnemyType, _SpawnPoint.RightLoc.position, _SpawnPoint.RightLoc.rotation);
                    break;
            }
        }

    }
}