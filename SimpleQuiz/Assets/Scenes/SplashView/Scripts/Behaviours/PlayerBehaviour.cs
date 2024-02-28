using Assets.Scripts.Models;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scenes.SplashView.Scripts.Behaviours
{
    public class PlayerBehaviour : MonoBehaviour
    {
        private static GameObject instance;

        [Min(2)]
        [SerializeField] private int nameLength = 5;

        private const string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string _startScene = "SplashView";
        public QuizPlayer QuizPlayer { get; private set; }
        public bool PlayerPlayed { get; private set; }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            if (instance == null)
            {
                instance = gameObject;
            }
            else
            {
                Destroy(gameObject);
            }

            SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        }

        private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            if (arg0.name == _startScene)
            {
                CreateNewPlayer();
            }
        }

        public void CreateNewPlayer()
        {
            QuizPlayer = new QuizPlayer
            {
                Name = RandomizeName(),
                Score = 0
            };
            PlayerPlayed = false;
        }

        private string RandomizeName()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < nameLength; i++)
            {
                stringBuilder.Append(_chars[Random.Range(0, _chars.Length)]);
            }
            return stringBuilder.ToString();
        }

        public void ChangeScore(int change)
        {
            PlayerPlayed = true;
            QuizPlayer.Score += change;
            if (QuizPlayer.Score < 0)
            {
                QuizPlayer.Score = 0;
            }
        }

        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
        }
    }
}