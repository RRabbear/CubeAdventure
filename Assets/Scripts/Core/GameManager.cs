using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.BaseUtils;
using Assets.Scripts.InputActions;
using UnityEngine.SceneManagement;
using Assets.Scripts.Gameplay.LevelLogic;

namespace Assets.Scripts.Core
{
    public class GameManager : MonoSingleton<GameManager>
    {
        public GameObject CurrentPlayer { get; private set; }
        public GameObject CurrentLevelSelector { get; private set; }

        public void SetCurrentPlayer(GameObject obj)
        {
            CurrentPlayer = obj;
        }

        public void SetCurrentLevelSelector(GameObject obj)
        {
            CurrentLevelSelector = obj;
        }

        public void LoadSelectedLevel()
        {
            StartCoroutine(LoadLevel((int)CurrentLevelSelector.GetComponent<LevelSelector>().SelectedLevel));
        }

        public void LoadMainLevel()
        {
            StartCoroutine(LoadLevel(0));
        }

        IEnumerator LoadLevel(int levelIndex)
        {
            InputActionsHandler.Instance.ShouldWait = true;

            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene(levelIndex);

            InputActionsHandler.Instance.ShouldWait = false;
        }
    }
}