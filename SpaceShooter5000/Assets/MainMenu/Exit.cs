using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{

    public class Exit : BasicButton
    {
        public override void TakeAction()
        {
            Application.Quit();
        }
    }
}