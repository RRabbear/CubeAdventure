using Assets.Scripts.Core;
using Assets.Scripts.Gameplay.CubeLogic;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Gameplay.LevelLogic
{
    public class LevelManager : MonoBehaviour
    {
        public enum ELevelState
        {
            Finished,
            Unfinished
        }

        [HideInInspector]
        public ELevelState Currentstate;

        [SerializeField]
        private List<CubePuzzle> CubePuzzleList;

        private void OnEnable()
        {
            Currentstate = ELevelState.Unfinished;

            foreach(var item in CubePuzzleList)
            {
                item.LevelStateUpdateEvent += UpdateLevelState;
            }
        }

        private void OnDisable()
        {
            foreach (var item in CubePuzzleList)
            {
                item.LevelStateUpdateEvent -= UpdateLevelState;
            }
        }

        private void UpdateLevelState()
        {
            foreach(var item in CubePuzzleList)
            {
                if(item.CurrentState == CubePuzzle.EPuzzleState.Triggered)
                {
                    continue;
                }
                else
                {
                    return;
                }
            }
            Currentstate = ELevelState.Finished;
            Debug.Log(Currentstate.ToString());

            GameManager.Instance.LoadMainLevel();
        }
    }
}