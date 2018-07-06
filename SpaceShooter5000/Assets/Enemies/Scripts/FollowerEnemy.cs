using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{

    public class FollowerEnemy : BaseEnemy
    {

        // Update is called once per frame
        void Update()
        {
           transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, Time.deltaTime * 6);
        }


    }
}