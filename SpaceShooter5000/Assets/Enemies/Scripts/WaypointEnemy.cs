using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter {

    public class WaypointEnemy : BaseEnemy {

        // Target point
        private Vector3 _CurrentWayPoint;

        // Slightly delay the movement between waypoints
        private float _DelayMovement;

        // Use this for initialization
        new void Start() {
            base.Start();
            _CurrentWayPoint = transform.position;
            _DelayMovement = 0;
        }

        // Update is called once per frame
        void Update() {

            if(_DelayMovement > 0)
            {
                _DelayMovement -= Time.deltaTime;

                if(_DelayMovement <= 0)
                {
                    _DelayMovement = 0;
                    _CurrentWayPoint = Player.transform.position;
                }
                return;
            }

            if (WayPointReached())
            {
                _DelayMovement = 1;
                return;
            }

            transform.position = Vector3.MoveTowards(transform.position, _CurrentWayPoint, Time.deltaTime * 8);
        }

        // Returns true if enemy is close enough to the waypoint
        private bool WayPointReached()
        {
            if(!CoordinatesClose(transform.position.x, _CurrentWayPoint.x))
            {
                return false;
            }

            if (!CoordinatesClose(transform.position.y, _CurrentWayPoint.y))
            {
                return false;
            }

            if (!CoordinatesClose(transform.position.z, _CurrentWayPoint.z))
            {
                return false;
            }

            return true;
        }

        // Returns true if given coordinates are close enough to each other
        private bool CoordinatesClose(float objectCoordinate, float targetCoordinate)
        {
            return Mathf.Abs(objectCoordinate - targetCoordinate) < 0.1f;
        }

    }
}