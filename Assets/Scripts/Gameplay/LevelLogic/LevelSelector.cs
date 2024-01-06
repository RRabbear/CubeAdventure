using Assets.Scripts.Core;
using System;
using UnityEngine;

namespace Assets.Scripts.Gameplay.LevelLogic
{
    public class LevelSelector : MonoBehaviour
    {
        private Collider _collider;
       
        public LevelLists.ELevels SelectedLevel;
        [SerializeField] private GameObject _unfinishedEffect;
        [SerializeField] private GameObject _finishedEffect;

        void Start()
        {
            _collider = GetComponent<Collider>();
        }

        public void UpdateLevelStateEffect(LevelManager.ELevelState levelState)
        {
            if (levelState == LevelManager.ELevelState.Unfinished)
            {
                _unfinishedEffect.SetActive(true);
                _finishedEffect.SetActive(false);
            }
            else if (levelState == LevelManager.ELevelState.Finished)
            {
                _unfinishedEffect.SetActive(false);
                _finishedEffect.SetActive(true);
            }
        }    

        private void OnTriggerEnter(Collider other)
        {
            if (_collider != null)
            {
                if (_collider.isTrigger)
                {
                    GameObject obj = other.gameObject;
                    if(obj == GameManager.Instance.CurrentPlayer.gameObject)
                    {
                        GameManager.Instance.SetCurrentLevelSelector(this);
                    }
                }
                else
                {
                    Debug.LogError(gameObject + "'s collider is not set to a trigger!");
                }
            }
            else
            {
                Debug.LogError(gameObject + " lacks a collider!");
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (_collider != null)
            {
                if (_collider.isTrigger)
                {
                    GameManager.Instance.SetCurrentLevelSelector(null);
                }
                else
                {
                    Debug.LogError(gameObject + "'s collider is not set to a trigger!");
                }
            }
            else
            {
                Debug.LogError(gameObject + " lacks a collider!");
            }
        }

    }
}