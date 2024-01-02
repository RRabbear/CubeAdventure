using Assets.Scripts.Core;
using Assets.Scripts.InputActions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.UI
{
    public class LevelSetting : MonoBehaviour
    {
        public void ResetButton()
        {
            if (GameManager.Instance.CurrentLevelIndex != 0)
            {
                GameManager.Instance.ResetCurrentLevel();
            }
        }

        public void EnterMainMenu()
        {
            GameManager.Instance.LoadSelectedLevel(0);
        }

        public void EnterMainScene()
        {
            GameManager.Instance.LoadMainLevel();
        }

        public void EnterFullScreenUI()
        {
            InputActionsHandler.Instance.ShouldWait = true;
        }

        public void ExitFullScreenUI()
        {
            InputActionsHandler.Instance.ShouldWait = false;
        }
    }
}