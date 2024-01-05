using System;
using Assets.Scripts.BaseUtils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Assets.Scripts.Core;

namespace Assets.Scripts.InputActions
{
    public class UIInputActionsHandler : Singleton<UIInputActionsHandler>, IDisposable
    {
        public delegate void UIEscape();
        public event UIEscape MainMenuEscape;
        public event UIEscape LevelSettingEscape;

        public void Initialized()
        {
            GameControls.Instance.asset.Enable();
            GameControls.Instance.UI.Escape.performed += EscapePerformed;
        }

        public void Dispose()
        {
            GameControls.Instance.UI.Escape.performed -= EscapePerformed;
        }

        private void EscapePerformed(InputAction.CallbackContext context)
        {
            if (GameManager.Instance.CurrentLevelIndex == 0)
            {
                MainMenuEscape();
            }
            else
            {
                LevelSettingEscape();
            }
        }
    }
}