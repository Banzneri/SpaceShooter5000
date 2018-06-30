using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{

    public class WaveSpawner : MonoBehaviour
    {

        // Waves of the level
        [SerializeField]
        private Wave[] _Waves;

        // Current Wave to be spawned
        private int _Current;

        // Use this for initialization
        void Start()
        {
            _Current = 0;
        }

        // Update is called once per frame
        void Update()
        {
            if(_Current >= _Waves.Length)
            {
                return;
            }

            bool ContinueCurrentWave = _Waves[_Current].SpawnWave();
            if (!ContinueCurrentWave)
            {
                _Current++;
            }
        }
    }
}