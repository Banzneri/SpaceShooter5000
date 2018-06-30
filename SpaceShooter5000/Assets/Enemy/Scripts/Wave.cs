using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{

    public class Wave : MonoBehaviour
    {

        // Bursts of this Wave
        [SerializeField]
        private Burst[] _Bursts;

        // Current Burst to be spawned
        private int _Current;

        // Use this for initialization
        void Start()
        {
            _Current = 0;
        }

        public bool SpawnWave()
        {
            if(_Current >= _Bursts.Length)
            {
                return false;
            }

            bool ContinueCurrentBurst = _Bursts[_Current].Bursting();

            if (!ContinueCurrentBurst)
            {
                _Current++;
            }

            return _Current < _Bursts.Length;
        }

    }
}