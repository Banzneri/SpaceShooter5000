using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceShooter
{

    public class ReturnMenu : BasicButton
    {
        public override void TakeAction()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}