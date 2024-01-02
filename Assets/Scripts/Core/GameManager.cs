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
        public int CurrentLevelIndex { get; private set; }
        [SerializeField]
        private Animator _sceneTransAnim;

        private void OnEnable()
        {
            SetCurrentLevelIndex(1);
        }

        public void SetCurrentPlayer(GameObject obj)
        {
            CurrentPlayer = obj;
        }

        public void SetCurrentLevelSelector(GameObject obj)
        {
            CurrentLevelSelector = obj;
        }

        public void SetCurrentLevelIndex(int index)
        {
            CurrentLevelIndex = index;
        }

        public void LoadSelectedLevel()
        {
            int index = (int)CurrentLevelSelector.GetComponent<LevelSelector>().SelectedLevel;
            StartCoroutine(LoadLevel(index));
            SetCurrentLevelIndex(index);
        }

        public void LoadSelectedLevel(int index)
        {
            StartCoroutine(LoadLevel(index));
            SetCurrentLevelIndex(index);
        }

        public void ResetCurrentLevel()
        {
            StartCoroutine(LoadLevel(CurrentLevelIndex));
        }

        public void LoadMainLevel()
        {
            StartCoroutine(LoadLevel(1));
            SetCurrentLevelIndex(1);
        }

        IEnumerator LoadLevel(int levelIndex)
        {
            InputActionsHandler.Instance.ShouldWait = true;
            _sceneTransAnim.gameObject.SetActive(true);
            _sceneTransAnim.SetTrigger("End");

            
            SceneManager.LoadScene(levelIndex);

            _sceneTransAnim.SetTrigger("Start");
            yield return new WaitForSeconds(1f);
            _sceneTransAnim.gameObject.SetActive(false);
            InputActionsHandler.Instance.ShouldWait = false;
        }
    }
}