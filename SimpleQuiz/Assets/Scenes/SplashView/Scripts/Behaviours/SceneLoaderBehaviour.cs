using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scenes.SplashView.Scripts.Behaviours
{
    public class SceneLoaderBehaviour : MonoBehaviour
    {
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }
}