using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scenes.SplashView.Scripts.Behaviours
{
    public class SceneLoaderBehaviour : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }
}