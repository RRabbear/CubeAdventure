using UnityEngine;
using Assets.Scripts.Gameplay.SaveSystem;
using Assets.Scripts.Core;
using System;

namespace Assets.Scripts.Gameplay.CubeLogic
{
    public class CubeManager : MonoBehaviour
    {
        [SerializeField] private GameObject _cubePlayer;

        private void OnEnable()
        {
            SavedCubeData data = SaveSystem.SaveSystem.LoadCubeData();
            if (data == null )
            {
                SaveSystem.SaveSystem.SaveCubeData(GameManager.Instance.GetCubeSavedPos());
                return;
            }
            else
            {
                Vector3 newPos = new Vector3();
                newPos.x = data.CubePlayerPos[0];
                newPos.y = data.CubePlayerPos[1];
                newPos.z = data.CubePlayerPos[2];

                _cubePlayer.transform.position = newPos;
            }
        }

        private void OnDisable()
        {
            SaveSystem.SaveSystem.SaveCubeData(GameManager.Instance.GetCubeSavedPos());
        }

        private void OnApplicationQuit()
        {
            SaveSystem.SaveSystem.SaveCubeData(GameManager.Instance.GetCubeSavedPos());
        }

        private void Update()
        {
            GameManager.Instance.CubePlayerPos = GameManager.Instance.GetActualPos(GameManager.Instance.CurrentPlayer.transform.position);
        }       
    }
}