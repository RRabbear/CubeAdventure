using Assets.Scripts.Core;
using Assets.Scripts.Gameplay.LevelLogic;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Gameplay.CubeLogic
{
    public class CubePuzzle : MonoBehaviour
    {
        public delegate void LevelStateUpdataDel();
        public event LevelStateUpdataDel LevelStateUpdateEvent;

        public enum EPuzzleState
        {
            NotTriggered,
            Triggered
        }

        public Cube.CubeProperty PuzzleAnswer;
        [HideInInspector]
        public EPuzzleState CurrentState;

        private Collider _collider;

        void Start()
        {
            _collider = gameObject.GetComponent<Collider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if(gameObject.GetComponent<Rigidbody>() == null)
            {
                Debug.LogError(gameObject + " lacks a rigidbody!");
                return;
            }

            if (_collider != null)
            {
                if(_collider.isTrigger)
                {
                    Cube enteredCube = other.gameObject.GetComponent<Cube>();
                    if(enteredCube != null && enteredCube.CurrentProperty == PuzzleAnswer)
                    {
                        UpdateCurrentState(EPuzzleState.Triggered);
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
            if (gameObject.GetComponent<Rigidbody>() == null)
            {
                Debug.LogError(gameObject + " lacks a rigidbody!");
                return;
            }

            if (_collider != null)
            {
                if (_collider.isTrigger)
                {         
                    UpdateCurrentState(EPuzzleState.NotTriggered);
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

        private void UpdateCurrentState(EPuzzleState state)
        {
            CurrentState = state;

            //temporary for masking a puzzle if finished
            if (state == EPuzzleState.Triggered)
            {
                LevelStateUpdateEvent();
                Debug.Log(gameObject + " state is " + CurrentState.ToString());
            }
            else
            {
                Debug.Log(gameObject + " state is " + CurrentState.ToString());
            }
        }
    }
}