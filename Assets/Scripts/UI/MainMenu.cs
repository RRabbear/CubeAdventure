using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.UI
{
    public class MainMenu : MonoBehaviour
    {
        public void PlayButton()
        {
            SceneManager.LoadSceneAsync(1);
        }

        public void QuitButton()
        {
            Application.Quit();
        }
    }
}