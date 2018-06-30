using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{

    public class SpawnPoint : MonoBehaviour
    {

        // Spawn location Left
        [SerializeField]
        private Transform _LeftLoc;

        // Spawn location Middle
        [SerializeField]
        private Transform _MiddleLoc;

        // Spawn location Right
        [SerializeField]
        private Transform _RightLoc;

        public Transform LeftLoc
        {
            get { return _LeftLoc; }
        }

        public Transform MiddleLoc
        {
            get { return _MiddleLoc; }
        }

        public Transform RightLoc
        {
            get { return _RightLoc; }
        }

        public void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(LeftLoc.position, 0.5f);
            Gizmos.DrawWireSphere(MiddleLoc.position, 0.5f);
            Gizmos.DrawWireSphere(RightLoc.position, 0.5f);
        }

    }
}