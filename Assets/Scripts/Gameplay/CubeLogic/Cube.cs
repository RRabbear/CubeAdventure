using Assets.Scripts.Core;
using Assets.Scripts.Gameplay.Player;
using UnityEngine;

namespace Assets.Scripts.Gameplay.CubeLogic
{
    public class Cube : MonoBehaviour
    {
        public enum CubeProperty
        {
            pink,       //0
            green,      //1
            orange,     //2
            blue,       //3
            white,      //4
            gray        //5
        }

        [HideInInspector]
        public CubeProperty CurrentProperty;

        [SerializeField]
        private CubeProperty CubeForwardProperty = (CubeProperty)0;
        [SerializeField]
        private CubeProperty CubeBackwardProperty = (CubeProperty)1;
        [SerializeField]
        private CubeProperty CubeLeftProperty = (CubeProperty)2;
        [SerializeField]
        private CubeProperty CubeRightProperty = (CubeProperty)3;
        [SerializeField]
        private CubeProperty CubeUpProperty = (CubeProperty)4;
        [SerializeField]
        private CubeProperty CubeDownProperty = (CubeProperty)5;

        // Start is called before the first frame update
        void Start()
        {
            if (GetComponent<PlayerController>().enabled == true)
            {
                GameManager.Instance.SetCurrentPlayer(gameObject);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnEnable()
        {
            CurrentProperty = CubeUpProperty;
        }

        public void UpdateProperty(Vector3 direction)
        {
            CubeProperty lastCubeForwardProperty = CubeForwardProperty;
            CubeProperty lastCubeBackwardProperty = CubeBackwardProperty;
            CubeProperty lastCubeLeftProperty = CubeLeftProperty;
            CubeProperty lastCubeRightProperty = CubeRightProperty;
            CubeProperty lastCubeUpProperty = CubeUpProperty;
            CubeProperty lastCubeDownProperty = CubeDownProperty;

            if (direction == Vector3.forward)
            {
                CubeForwardProperty = lastCubeUpProperty;
                CubeBackwardProperty = lastCubeDownProperty;
                CubeUpProperty = lastCubeBackwardProperty;
                CubeDownProperty = lastCubeForwardProperty;

                CurrentProperty = CubeUpProperty;
            }
            else if (direction == Vector3.left)
            {
                CubeLeftProperty = lastCubeUpProperty;
                CubeRightProperty = lastCubeDownProperty;
                CubeUpProperty = lastCubeRightProperty;
                CubeDownProperty = lastCubeLeftProperty;

                CurrentProperty = CubeUpProperty;
            }
            else if (direction == Vector3.back)
            {
                CubeForwardProperty = lastCubeDownProperty;
                CubeBackwardProperty = lastCubeUpProperty;
                CubeUpProperty = lastCubeForwardProperty;
                CubeDownProperty = lastCubeBackwardProperty;

                CurrentProperty = CubeUpProperty;
            }
            else if (direction == Vector3.right)
            {
                CubeLeftProperty = lastCubeDownProperty;
                CubeRightProperty = lastCubeUpProperty;
                CubeUpProperty = lastCubeLeftProperty;
                CubeDownProperty = lastCubeRightProperty;

                CurrentProperty = CubeUpProperty;
            }
            else
            {
                Debug.LogError("Wrong Direction in Cube.UpdateProperty!");
            }
        }

        public void UpdateCubePlayer(bool isCurrentCube)
        {
            if (isCurrentCube)
            {
                LayerManager.SetLayer(gameObject, (int)ELayerName.PostCube);
                GameManager.Instance.SetCurrentPlayer(gameObject);
            }
            else
            {
                LayerManager.SetLayer(gameObject, (int)ELayerName.NoPostCube);
            }
        }
    }
}