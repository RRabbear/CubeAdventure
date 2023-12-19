using Assets.Scripts.Core;
using UnityEngine;

namespace Assets.Scripts.Gameplay.LevelLogic
{
    public class LevelSelector : MonoBehaviour
    {
        private Collider _collider;
       
        public LevelLists.ELevels SelectedLevel;

        void Start()
        {
            _collider = GetComponent<Collider>();
        }

        

        private void OnTriggerEnter(Collider other)
        {
            if (_collider != null)
            {
                if (_collider.isTrigger)
                {
                    GameObject obj = other.gameObject;
                    if(obj == GameManager.Instance.CurrentPlayer)
                    {
                        GameManager.Instance.SetCurrentLevelSelector(this.gameObject);
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