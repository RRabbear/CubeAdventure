using Assets.Scripts.Core;
using Assets.Scripts.InputActions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.UI
{
    public class LevelSetting : MonoBehaviour
    {
        [SerializeField] private GameObject _buttonLevelSetting;
        [SerializeField] private GameObject _panelLevelSetting;

        [SerializeField] private GameObject _levelSettingFirst;

        private void OnEnable()
        {
            UIInputActionsHandler.Instance.LevelSettingEscape += HandleUILevelSetting;

            SetLevelSettingFirst();
        }

        private void SetLevelSettingFirst()
        {
            EventSystem.current.SetSelectedGameObject(_levelSettingFirst);
            _levelSettingFirst.GetComponentInChildren<TextMeshProUGUI>().fontStyle |= FontStyles.Underline;
        }

        private void OnDisable()
        {
            UIInputActionsHandler.Instance.LevelSettingEscape -= HandleUILevelSetting;
        }

        public void HandleUILevelSetting()
        {
            if (_buttonLevelSetting.activeSelf)
            {
                _buttonLevelSetting.SetActive(false);
                _panelLevelSetting.SetActive(true);

                SetLevelSettingFirst();

                EnterFullScreenUI();
            }
            else
            {
                OnButtonContinue();
            }
        }

        public void OnButtonContinue()
        {
            _buttonLevelSetting.SetActive(true);
            _panelLevelSetting.SetActive(false);
            ExitFullScreenUI();
        }

        public void OnButtonReset()
        {
            if (GameManager.Instance.CurrentLevelIndex != 0)
            {
                GameManager.Instance.ResetCurrentLevel();
            }
            _buttonLevelSetting.SetActive(true);
            _panelLevelSetting.SetActive(false);

            ExitFullScreenUI();
        }

        public void EnterMainMenu()
        {
            GameManager.Instance.LoadMainMenu();
        }

        public void EnterMainScene()
        {
            GameManager.Instance.LoadMainLevel();
        }

        public void EnterFullScreenUI()
        {
            InputActionsHandler.Instance.Dispose();
        }

        public void ExitFullScreenUI()
        {
            InputActionsHandler.Instance.Initialized();
        }
    }
}