using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.BaseUtils;
using UnityEngine.InputSystem;
using System;
using Assets.Scripts.Core;

namespace Assets.Scripts.InputActions
{
    public class InputActionsHandler : Singleton<InputActionsHandler>, IDisposable
    {
        public bool ShouldWait;

        public delegate void PlayerMovement();       
        public event PlayerMovement MoveW;
        public event PlayerMovement MoveA;
        public event PlayerMovement MoveS;
        public event PlayerMovement MoveD;

        public delegate void PlayerApply();
        public event PlayerApply ApplySpace;

        public delegate void PlayerReset();
        public event PlayerReset ResetLevel;

        public void Initialized()
        {
            GameControls.Instance.asset.Enable();
            GameControls.Instance.Player.MoveW.performed += MoveWPerformed;
            GameControls.Instance.Player.MoveA.performed += MoveAPerformed;
            GameControls.Instance.Player.MoveS.performed += MoveSPerformed;
            GameControls.Instance.Player.MoveD.performed += MoveDPerformed;
            GameControls.Instance.Player.Apply.performed += ApplyPerformed;
            GameControls.Instance.Player.Reset.performed += ResetPerformed;
        }

        public void Dispose()
        {
            GameControls.Instance.Player.MoveW.performed -= MoveWPerformed;
            GameControls.Instance.Player.MoveA.performed -= MoveAPerformed;
            GameControls.Instance.Player.MoveS.performed -= MoveSPerformed;
            GameControls.Instance.Player.MoveD.performed -= MoveDPerformed;
            GameControls.Instance.Player.Apply.performed -= ApplyPerformed;
        }
        private void ResetPerformed(InputAction.CallbackContext context)
        {
            if (!ShouldWait && GameManager.Instance.CurrentPlayer != null)
                ResetLevel();
        }

        private void ApplyPerformed(InputAction.CallbackContext context)
        {
            if (!ShouldWait && GameManager.Instance.CurrentPlayer != null)
                ApplySpace();
        }

        private void MoveWPerformed(InputAction.CallbackContext obj)
        {
            if (!ShouldWait && GameManager.Instance.CurrentPlayer != null)
                MoveW();
        }

        private void MoveAPerformed(InputAction.CallbackContext obj)
        {
            if (!ShouldWait && GameManager.Instance.CurrentPlayer != null)
                MoveA();
        }

        private void MoveSPerformed(InputAction.CallbackContext obj)
        {
            if (!ShouldWait && GameManager.Instance.CurrentPlayer != null)
                MoveS();
        }

        private void MoveDPerformed(InputAction.CallbackContext obj)
        {
            if (!ShouldWait && GameManager.Instance.CurrentPlayer != null)
                MoveD();
        }
    }
}