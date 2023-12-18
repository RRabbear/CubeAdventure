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
                    if(enteredCube == null || CurrentState == EPuzzleState.Triggered)
                    {
                        return;
                    }
                    if(enteredCube.CurrentProperty == PuzzleAnswer)
                    {
                        UpdateCurrentState(EPuzzleState.Triggered);
                    }
                    else
                    {
                        Debug.Log("2");
                        UpdateCurrentState(EPuzzleState.NotTriggered);
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
                    Debug.Log("1");
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
            GameObject flagCube = this.gameObject.transform.GetChild(0).gameObject;
            if(flagCube == null)
            {
                Debug.LogError("Can't finish the task: UpdateCurrentState of " + gameObject.name + "! Check if there is a FlagCube!");
                return;
            }
            //temporary for masking a puzzle if finished
            if (state == EPuzzleState.Triggered)
            {
                flagCube.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.green);

                LevelStateUpdateEvent();
                Debug.Log(gameObject + " state is " + CurrentState.ToString());
            }
            else if( state == EPuzzleState.NotTriggered) 
            {
                flagCube.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.white);
                Debug.Log(gameObject + " state is " + CurrentState.ToString());
            }
        }
    }
}