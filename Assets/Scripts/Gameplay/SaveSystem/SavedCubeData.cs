using Assets.Scripts.Gameplay.CubeLogic;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Gameplay.SaveSystem
{
    [System.Serializable]
    public class SavedCubeData
    {
        public float[] CubePlayerPos;

        public SavedCubeData(Vector3 pos)
        {
            CubePlayerPos = new float[3];
            CubePlayerPos[0] = pos.x;
            CubePlayerPos[1] = 0;
            CubePlayerPos[2] = pos.z;
        }
    }
}