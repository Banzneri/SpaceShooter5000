using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceShooter
{

    public class Continue : BasicButton
    {

        [SerializeField]
        private PauseMenu _pau_Menu;

        public override void TakeAction()
        {
            // resume game
            _pau_Menu.Resume();
        }

    }
}