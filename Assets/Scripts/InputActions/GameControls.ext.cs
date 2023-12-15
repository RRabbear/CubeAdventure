using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.InputActions
{
    public partial class GameControls
    {
        private static GameControls _instance;

        public static GameControls Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new GameControls();
                }
                return _instance;
            }
            set
            {
                _instance = value;
            }
        }
    }
}