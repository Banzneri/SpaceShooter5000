using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{

    public class ButtonManager : MonoBehaviour
    {

        #region Public Variables

        // Buttons. 0 = Play; 1 = Exit
        [SerializeField]
        private BasicButton[] _bas_Buttons;

        // Selected Button Color
        [SerializeField]
        private Color _col_Selected;
        public Color col_Selected
        {
            get { return _col_Selected; }
        }

        // Idle Button Color
        [SerializeField]
        private Color _col_Idle;
        public Color col_Idle
        {
            get { return _col_Idle; }
        }

        #endregion

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            // Request buttons to change color to Idle
            for(int i = 0; i < _bas_Buttons.Length; i++)
            {
                _bas_Buttons[i].ColorChangeRequest(false);
            }

            // Cast ray and go through the Buttons to compare result to them
            Ray ray;
            RaycastHit hit;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                for(int i = 0; i < _bas_Buttons.Length; i++)
                {

                    // if Mouse is over Button, change color
                    if (hit.collider.gameObject.Equals(_bas_Buttons[i].gameObject))
                    {
                        _bas_Buttons[i].ColorChangeRequest(true);

                        // If Left-Clicked, request button to take action
                        if(Input.GetMouseButtonDown(0))
                        {
                            _bas_Buttons[i].ActionRequest();
                        }
                    }
                }
            }
        }


    }
}