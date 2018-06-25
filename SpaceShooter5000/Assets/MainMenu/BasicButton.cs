using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{

    abstract public class BasicButton : MonoBehaviour
    {

        #region Variables

        // ButtonManager
        [SerializeField]
        private ButtonManager _but_Manager;

        // SpriteRenderer
        [SerializeField]
        private SpriteRenderer _spr_Renderer;

        // Timer that indicates if button is activated lately
        private float _flo_Timer;

        #endregion

        #region Methods

        // What button does
        public abstract void TakeAction();

        // Use this for initialization
        void Start()
        {

            // Check if but_Manager is assigned
            if(_but_Manager == null)
            {
                _but_Manager = transform.parent.GetComponent<ButtonManager>();
            }

            // If but_Manager is still not found, report error
            if(_but_Manager == null)
            {
                Debug.LogError("Button Manager not found");
            }


            // Check if spr_Renderer is assigned
            if (_spr_Renderer == null)
            {
                _spr_Renderer = GetComponent<SpriteRenderer>();
            }

            // If spr_Renderer is still not found, report error
            if (_spr_Renderer == null)
            {
                Debug.LogError("Sprite Renderer not found");
            }


            // Set Starting color for button
            _spr_Renderer.color = _but_Manager.col_Idle;

            // Button is not activated
            _flo_Timer = 0;
        }

        void Update()
        {
            if(_flo_Timer > 0)
            {
                _flo_Timer -= Time.deltaTime;

                // used to change color
                float RGB_Value;

                if(_flo_Timer > 0.35f)
                {
                    RGB_Value = 0.1f;
                } else
                {
                    RGB_Value = -0.045f;
                }
                _spr_Renderer.color += new Color(RGB_Value, RGB_Value, RGB_Value, 0);

                if(_flo_Timer <= 0)
                {
                    TakeAction();
                    _flo_Timer = 0;
                }
            }
        }

        // Checks if color can be changed
        public void ColorChangeRequest(bool selected)
        {
            // Exit if button is activated recently
            if(_flo_Timer > 0)
            {
                return;
            }

            if (selected)
            {
                _spr_Renderer.color = _but_Manager.col_Selected;
            } else
            {
                _spr_Renderer.color = _but_Manager.col_Idle;
            }
        }

        // Checks if the assigned action of the button can be done
        public void ActionRequest()
        {
            // Exit if button is activated recently
            if (_flo_Timer > 0)
            {
                return;
            }

            // Prepare Action
            ColorChangeRequest(true);
            _flo_Timer = 0.45f;
        }

        #endregion
    }
}