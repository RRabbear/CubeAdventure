using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.BaseUtils;
using Assets.Scripts.InputActions;
using System;
using UnityEngine.Events;
using Assets.Scripts.Gameplay.CubeLogic;
using Assets.Scripts.Core;

namespace Assets.Scripts.Gameplay.Player
{
    public class PlayerController : MonoBehaviour
    {
        private GameObject raycastObjW;
        private GameObject raycastObjA;
        private GameObject raycastObjS;
        private GameObject raycastObjD;

        private void Start()
        {
            InputActionsHandler.Instance.Initialized();
        }

        private void OnEnable()
        {
            InputActionsHandler.Instance.MoveW += HandleW;
            InputActionsHandler.Instance.MoveA += HandleA;
            InputActionsHandler.Instance.MoveS += HandleS;
            InputActionsHandler.Instance.MoveD += HandleD;
            InputActionsHandler.Instance.ApplySpace += HandleSpace;

            RaycastObjWASD();
        }

        private void OnDisable()
        {
            InputActionsHandler.Instance.MoveW -= HandleW;
            InputActionsHandler.Instance.MoveA -= HandleA;
            InputActionsHandler.Instance.MoveS -= HandleS;
            InputActionsHandler.Instance.MoveD -= HandleD;
            InputActionsHandler.Instance.ApplySpace -= HandleSpace;
        }
        private void HandleSpace()
        {
            if(GameManager.Instance.CurrentLevelSelector != null) 
            {
                GameManager.Instance.LoadSelectedLevel();
            }
        }

        private void HandleW()
        {
            if (raycastObjW != null)
            {
                if(raycastObjW.GetComponent<Cube>() == null)
                {
                    StartCoroutine(CantMove(Vector3.forward, raycastObjW));
                    return;
                }

                if (gameObject.GetComponent<Cube>().CurrentProperty == raycastObjW.GetComponent<Cube>().CurrentProperty)
                {
                    gameObject.GetComponent<PlayerController>().enabled = false;
                    raycastObjW.GetComponent<PlayerController>().enabled = true;

                    gameObject.GetComponent<Cube>().UpdateCubePlayer(false);
                    raycastObjW.GetComponent<Cube>().UpdateCubePlayer(true);
                }
                else
                {
                    raycastObjW.GetComponent<PlayerController>().enabled = true;
                    if (raycastObjW.GetComponent<PlayerController>().raycastObjW == null)
                    {
                        StartCoroutine(PushCube(Vector3.forward, raycastObjW));                        
                    }
                    else
                    {
                        StartCoroutine(CantPushCube(Vector3.forward, raycastObjW));
                    }
                    raycastObjW.GetComponent<PlayerController>().enabled = false;
                }
                RaycastObjWASD();
                return;
            }
            else
            {
                StartCoroutine(RollCube(Vector3.forward));
                gameObject.GetComponent<Cube>().UpdateProperty(Vector3.forward);
            }
        }

        private void HandleA()
        {
            if (raycastObjA != null)
            {
                if (raycastObjA.GetComponent<Cube>() == null)
                {
                    StartCoroutine(CantMove(Vector3.left, raycastObjA));
                    return;
                }

                if (gameObject.GetComponent<Cube>().CurrentProperty == raycastObjA.GetComponent<Cube>().CurrentProperty)
                {
                    gameObject.GetComponent<PlayerController>().enabled = false;
                    raycastObjA.GetComponent<PlayerController>().enabled = true;

                    gameObject.GetComponent<Cube>().UpdateCubePlayer(false);
                    raycastObjA.GetComponent<Cube>().UpdateCubePlayer(true);
                }
                else
                {
                    raycastObjA.GetComponent<PlayerController>().enabled = true;
                    if (raycastObjA.GetComponent<PlayerController>().raycastObjA == null)
                    {
                        StartCoroutine(PushCube(Vector3.left, raycastObjA));
                    }
                    else
                    {
                        StartCoroutine(CantPushCube(Vector3.left, raycastObjA));
                    }
                    raycastObjA.GetComponent<PlayerController>().enabled = false;
                }
                RaycastObjWASD();
                return;
            }
            else
            {
                StartCoroutine(RollCube(Vector3.left));
                gameObject.GetComponent<Cube>().UpdateProperty(Vector3.left);
            }
        }

        private void HandleS()
        {
            if (raycastObjS != null)
            {
                if (raycastObjS.GetComponent<Cube>() == null)
                {
                    StartCoroutine(CantMove(Vector3.back, raycastObjS));
                    return;
                }

                if (gameObject.GetComponent<Cube>().CurrentProperty == raycastObjS.GetComponent<Cube>().CurrentProperty)
                {
                    gameObject.GetComponent<PlayerController>().enabled = false;
                    raycastObjS.GetComponent<PlayerController>().enabled = true;

                    gameObject.GetComponent<Cube>().UpdateCubePlayer(false);
                    raycastObjS.GetComponent<Cube>().UpdateCubePlayer(true);
                }
                else
                {
                    raycastObjS.GetComponent<PlayerController>().enabled = true;
                    if (raycastObjS.GetComponent<PlayerController>().raycastObjS == null)
                    {
                        StartCoroutine(PushCube(Vector3.back, raycastObjS));
                    }
                    else
                    {
                        StartCoroutine(CantPushCube(Vector3.back, raycastObjS));
                    }
                    raycastObjS.GetComponent<PlayerController>().enabled = false;
                }
                RaycastObjWASD();
                return;
            }
            else
            {
                StartCoroutine(RollCube(Vector3.back));
                gameObject.GetComponent<Cube>().UpdateProperty(Vector3.back);
            }
        }

        private void HandleD()
        {
            if(raycastObjD != null)
            {
                if (raycastObjD.GetComponent<Cube>() == null)
                {
                    StartCoroutine(CantMove(Vector3.right, raycastObjD));
                    return;
                }

                if (gameObject.GetComponent<Cube>().CurrentProperty == raycastObjD.GetComponent<Cube>().CurrentProperty)
                {
                    gameObject.GetComponent<PlayerController>().enabled = false;
                    raycastObjD.GetComponent<PlayerController>().enabled = true;

                    gameObject.GetComponent<Cube>().UpdateCubePlayer(false);
                    raycastObjD.GetComponent<Cube>().UpdateCubePlayer(true);
                }
                else
                {
                    raycastObjD.GetComponent<PlayerController>().enabled = true;
                    if (raycastObjD.GetComponent<PlayerController>().raycastObjD == null)
                    {
                        StartCoroutine(PushCube(Vector3.right, raycastObjD));
                    }
                    else
                    {
                        StartCoroutine(CantPushCube(Vector3.right, raycastObjD));
                    }
                    raycastObjD.GetComponent<PlayerController>().enabled = false;
                }
                RaycastObjWASD();
                return;
            }
            else
            {
                StartCoroutine(RollCube(Vector3.right));
                gameObject.GetComponent<Cube>().UpdateProperty(Vector3.right);
            }
        }

        IEnumerator RollCube(Vector3 direction)
        {
            InputActionsHandler.Instance.ShouldWait = true;

            float remainingAngle = 90f;
            Vector3 rotatePoint = transform.position + direction / 2 + Vector3.down / 2;
            Vector3 rotateAxis = Vector3.Cross(Vector3.up, direction);

            while (remainingAngle > 0 )
            {
                float rotateAngle = Mathf.Min(Time.deltaTime * 300, remainingAngle);
                transform.RotateAround(rotatePoint, rotateAxis, rotateAngle);
                remainingAngle -= rotateAngle;
                yield return null;
            }

            RaycastObjWASD();
            InputActionsHandler.Instance.ShouldWait = false;
        }

        IEnumerator PushCube(Vector3 direction, GameObject obj)
        {
            InputActionsHandler.Instance.ShouldWait = true;

            float remainingDistanceThis = 1f;
            float remainingDistanceObj = 1f;
            while (remainingDistanceThis > 0)
            {
                float trasnlateDistanceThis = Mathf.Min(Time.deltaTime * 8, remainingDistanceThis);                
                transform.Translate(direction * trasnlateDistanceThis, Space.World);
                remainingDistanceThis -= trasnlateDistanceThis;
                if (remainingDistanceObj > 0)
                {
                    float trasnlateDistanceObj = Mathf.Min(Time.deltaTime * 10, remainingDistanceObj);
                    obj.transform.Translate(direction * trasnlateDistanceObj, Space.World);
                    remainingDistanceObj -= trasnlateDistanceObj;
                }
                yield return null;
            }

            RaycastObjWASD();
            InputActionsHandler.Instance.ShouldWait = false;
        }

        IEnumerator CantPushCube(Vector3 direction, GameObject obj)
        {
            InputActionsHandler.Instance.ShouldWait = true;

            float remainingDistanceThis = 0.2f;
            float remainingDistanceObj = 0.1f;
            while (remainingDistanceThis > 0)
            {
                float trasnlateDistanceThis = Mathf.Min(Time.deltaTime * 8, remainingDistanceThis);
                transform.Translate(direction * trasnlateDistanceThis, Space.World);
                remainingDistanceThis -= trasnlateDistanceThis;
                if (remainingDistanceObj > 0)
                {
                    float trasnlateDistanceObj = Mathf.Min(Time.deltaTime * 10, remainingDistanceObj);
                    obj.transform.Translate(direction * trasnlateDistanceObj, Space.World);
                    remainingDistanceObj -= trasnlateDistanceObj;
                }
                yield return null;
            }
            remainingDistanceThis = 0.2f;
            remainingDistanceObj = 0.1f;
            while (remainingDistanceThis > 0)
            {
                float trasnlateDistanceThis = Mathf.Min(Time.deltaTime * 2, remainingDistanceThis);
                transform.Translate(direction * (-1) * trasnlateDistanceThis, Space.World);
                remainingDistanceThis -= trasnlateDistanceThis;
                if (remainingDistanceObj > 0)
                {
                    float trasnlateDistanceObj = Mathf.Min(Time.deltaTime, remainingDistanceObj);
                    obj.transform.Translate(direction * (-1) * trasnlateDistanceObj, Space.World);
                    remainingDistanceObj -= trasnlateDistanceObj;
                }
                yield return null;
            }

            RaycastObjWASD();
            InputActionsHandler.Instance.ShouldWait = false;
        }

        IEnumerator CantMove(Vector3 direction, GameObject obj)
        {
            InputActionsHandler.Instance.ShouldWait = true;

            float remainingDistanceThis = 0.15f;
            while (remainingDistanceThis > 0)
            {
                float trasnlateDistanceThis = Mathf.Min(Time.deltaTime * 8, remainingDistanceThis);
                transform.Translate(direction * trasnlateDistanceThis, Space.World);
                remainingDistanceThis -= trasnlateDistanceThis;
                yield return null;
            }
            remainingDistanceThis = 0.15f;
            while (remainingDistanceThis > 0)
            {
                float trasnlateDistanceThis = Mathf.Min(Time.deltaTime * 2, remainingDistanceThis);
                transform.Translate(direction * (-1) * trasnlateDistanceThis, Space.World);
                remainingDistanceThis -= trasnlateDistanceThis;
                yield return null;
            }

            RaycastObjWASD();
            InputActionsHandler.Instance.ShouldWait = false;
        }

        private GameObject RaycastObejct(Vector3 startPos, Vector3 direction)
        {
            Ray ray = new Ray(startPos, direction);
            Debug.DrawLine(ray.origin, ray.origin + ray.direction, Color.red, 2.0f);
            if (Physics.Raycast(ray, out RaycastHit hit, 1.0f, 1 << (int)ELayerName.NoPostCube | 1 << (int)ELayerName.PostCube | 1 << (int)ELayerName.Collider) )
            {
                return hit.collider.gameObject;
            }
            return null;
        }

        private void RaycastObjWASD()
        {
            raycastObjW = RaycastObejct(transform.position, new Vector3(0, 0, 1));
            raycastObjA = RaycastObejct(transform.position, new Vector3(-1, 0, 0));
            raycastObjS = RaycastObejct(transform.position, new Vector3(0, 0, -1));
            raycastObjD = RaycastObejct(transform.position, new Vector3(1, 0, 0));
            raycastObjW = raycastObjW == gameObject ? null : raycastObjW;
            raycastObjA = raycastObjA == gameObject ? null : raycastObjA;
            raycastObjS = raycastObjS == gameObject ? null : raycastObjS;
            raycastObjD = raycastObjD == gameObject ? null : raycastObjD;
        }
    }
}