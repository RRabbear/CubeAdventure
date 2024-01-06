using Assets.Scripts.Core;
using Assets.Scripts.Gameplay.SaveSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Gameplay.LevelLogic
{
    public class LevelSelectorManager : MonoBehaviour
    {
        [SerializeField] private List<LevelSelector> _levelSelectorList;

        private void OnEnable()
        {        
            SavedLevelData data = SaveSystem.SaveSystem.LoadLevelData();
            GameManager.Instance.levelStateDic = data._levelStateDic;

            LevelSelectorManager levelSelectorManager = FindObjectOfType<LevelSelectorManager>();
            if (levelSelectorManager == null)
            {
                Debug.LogError("Can't find LevelSelectorManager!");
            }
            else
            {
                levelSelectorManager.UpdateAllLevelSelectorEffect(GameManager.Instance.levelStateDic);
            }
        }

        public void UpdateAllLevelSelectorEffect(Dictionary<LevelLists.ELevels, LevelManager.ELevelState> dic)
        {
            foreach (var level in dic.Keys)
            {
                foreach (var levelSelector in _levelSelectorList)
                {
                    if (level == levelSelector.SelectedLevel)
                    {
                        levelSelector.UpdateLevelStateEffect(dic[level]);
                        break;
                    }
                }
            }
        }

        public Dictionary<LevelSelector, LevelManager.ELevelState> InitializeLevelStateDic()
        {
            var dic = new Dictionary<LevelSelector, LevelManager.ELevelState>();

            foreach (var levelSelector in _levelSelectorList)
            {
                dic.Add(levelSelector, LevelManager.ELevelState.Unfinished);
            }

            return dic;
        }
    }
}