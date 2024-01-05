using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;
using Assets.Scripts.Core;
using Assets.Scripts.InputActions;

namespace Assets.Scripts.UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _mainMenuFirst;
        //[SerializeField] private GameObject _settingMenuFirst;

        private void OnEnable()
        {
            EventSystem.current.SetSelectedGameObject(_mainMenuFirst);
            _mainMenuFirst.GetComponentInChildren<TextMeshProUGUI>().fontStyle |= FontStyles.Underline;

            UIInputActionsHandler.Instance.MainMenuEscape += QuitButton;
        }

        public void PlayButton()
        {
            GameManager.Instance.LoadSelectedLevel(1);
        }

        public void QuitButton()
        {
            Application.Quit();
        }
    }
}