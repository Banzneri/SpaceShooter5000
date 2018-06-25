using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceShooter
{

    public class Play : BasicButton
    {

        public override void TakeAction()
        {
            // start game
            SceneManager.LoadScene("Stage");
        }

    }
}