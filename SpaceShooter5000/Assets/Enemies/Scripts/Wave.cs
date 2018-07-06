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
            // Are all Bursts spawned
            if(_Current >= _Bursts.Length)
            {
                return false;
            }

            // Is Burst finished
            bool ContinueCurrentBurst = _Bursts[_Current].Bursting();

            // If burst is finished, move to the next one
            if (!ContinueCurrentBurst)
            {
                _Current++;
            }

            // Return true if all bursts are not spawned yet
            return _Current < _Bursts.Length;
        }

    }
}