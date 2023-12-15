using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public enum ELayerName
    {
        Default,
        TransparentFX,
        IgnoreRaycast,
        UserLayer3,
        Water,
        UI,
        UserLayer6,
        PostCube,
        NoPostCube
    }

    public class LayerManager
    {
        public static void SetLayer(GameObject obj, int layerIndex)
        {
            obj.layer = layerIndex;
            foreach (Transform child in obj.transform)
            {
                if (child.CompareTag("Shadow"))
                    continue;
                SetLayer(child.gameObject, layerIndex);
            }
        }
    }
}