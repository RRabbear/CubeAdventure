using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.BaseUtils;
using Assets.Scripts.InputActions;
using UnityEngine.SceneManagement;
using Assets.Scripts.Gameplay.LevelLogic;
using Assets.Scripts.Gameplay.SaveSystem;
using UnityEditor.SearchService;
using UnityEditor.SceneManagement;
using Assets.Scripts.Gameplay.CubeLogic;

namespace Assets.Scripts.Core
{
    public class GameManager : MonoSingleton<GameManager>
    {
        public Cube CurrentPlayer { get; private set; }
        public LevelSelector CurrentLevelSelector { get; private set; }
        public int CurrentLevelIndex { get; private set; }

        public Dictionary<LevelLists.ELevels, LevelManager.ELevelState> levelStateDic;

        [SerializeField] private Animator _sceneTransAnim;
        [SerializeField] private List<LevelLists.ELevels> _levelLists;

        private void OnEnable()
        {
            UIInputActionsHandler.Instance.Initialized();        
        }

        public void SetCurrentPlayer(Cube obj)
        {
            CurrentPlayer = obj;
        }

        public void SetCurrentLevelSelector(LevelSelector obj)
        {
            CurrentLevelSelector = obj;
        }

        public void SetCurrentLevelIndex(int index)
        {
            CurrentLevelIndex = index;
        }

        public void InitializeLevelStateDic()
        {
            levelStateDic = new Dictionary<LevelLists.ELevels, LevelManager.ELevelState>();
            foreach (var level in _levelLists)
            {
                levelStateDic.Add(level, LevelManager.ELevelState.Unfinished);
            }
        }

        public void UpdateLevelStateDic(LevelSelector levelSelector)
        {
            levelStateDic[levelSelector.SelectedLevel] = LevelManager.ELevelState.Finished;
            SaveSystem.SaveLevelData(levelStateDic);
        }

        public void LoadSelectedLevel()
        {
            int index = (int)CurrentLevelSelector.SelectedLevel;
            LoadSelectedLevel(index);
        }

        public void LoadSelectedLevel(int index)
        {
            StartCoroutine(LoadLevel(index));
            SetCurrentLevelIndex(index);
        }

        public void ResetCurrentLevel()
        {
            LoadSelectedLevel(CurrentLevelIndex);
        }

        public void LoadMainMenu()
        {
            LoadSelectedLevel(0);
        }

        public void LoadMainLevel()
        {
            LoadSelectedLevel(1);                     
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