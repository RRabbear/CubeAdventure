using Assets.Scripts.Core;
using Assets.Scripts.Gameplay.LevelLogic;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
        [HideInInspector]
        public Cube CurrentPuzzleCube;

        private Collider _collider;
        private Color _baseColor;
        private GameObject _flagCube;

        void Start()
        {
            _collider = gameObject.GetComponent<Collider>();
            _baseColor = gameObject.GetComponent<Renderer>().material.color;
            _flagCube = this.gameObject.transform.GetChild(0).gameObject;
            _flagCube.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", new Color(_baseColor.r, _baseColor.g, _baseColor.b, 0.05f));
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
                        CurrentPuzzleCube = enteredCube;
                        UpdateCurrentState(EPuzzleState.Triggered);
                    }
                    else
                    {
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
            if(_flagCube == null)
            {
                Debug.LogError("Can't finish the task: UpdateCurrentState of " + gameObject.name + "! Check if there is a FlagCube!");
                return;
            }
            //temporary for masking a puzzle if finished
            if (state == EPuzzleState.Triggered)
            {
                //flagCube.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.green);
                _flagCube.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", new Color(0f, 1f, 0f, 0.05f));

                LevelStateUpdateEvent();
                Debug.Log(gameObject + " state is " + CurrentState.ToString());
            }
            else if( state == EPuzzleState.NotTriggered) 
            {
                //flagCube.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.white);
                _flagCube.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", new Color(_baseColor.r, _baseColor.g, _baseColor.b, 0.05f));
                Debug.Log(gameObject + " state is " + CurrentState.ToString());
            }
        }
    }
}