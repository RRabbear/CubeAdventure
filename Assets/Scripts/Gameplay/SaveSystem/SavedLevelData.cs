using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Gameplay.LevelLogic;

namespace Assets.Scripts.Gameplay.SaveSystem
{
    [System.Serializable]
    public class SavedLevelData
    {
        public Dictionary<LevelLists.ELevels, LevelManager.ELevelState> _levelStateDic;
        public SavedLevelData(Dictionary<LevelLists.ELevels, LevelManager.ELevelState> dic)
        {
            _levelStateDic = dic;
        }
    }
}