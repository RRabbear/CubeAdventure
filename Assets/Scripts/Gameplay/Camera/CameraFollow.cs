using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Core;

namespace Assets.Scripts.Gameplay.Camera
{
    public class CameraFollow : MonoBehaviour
    {
        private readonly float _smoothSpeed = 0.005f;
        private Vector3 _offset;

        private void Start()
        {
            _offset = transform.position;
        }

        private void LateUpdate()
        {
            Vector3 disiredPos = GameManager.Instance.CurrentPlayer.transform.position + _offset;
            Vector3 smoothedPos = Vector3.Lerp(transform.position, disiredPos, _smoothSpeed);
            transform.position = smoothedPos;
        }
    }
}