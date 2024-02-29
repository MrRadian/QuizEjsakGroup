using Assets.Scenes.SplashView.Scripts.Managers;
using Assets.Scripts.Models;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scenes.SplashView.Scripts.Behaviours
{
    public class PlayerBehaviour : MonoBehaviour
    {
        private static GameObject instance;

        [Min(2)]
        [SerializeField] private int nameLength = 5;

        private PlayerNameManager _playerNameManager;
        public QuizPlayer QuizPlayer { get; private set; }
        private const string _startScene = "SplashView";
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
            _playerNameManager = new PlayerNameManager();
            SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        }

        private void SceneManager_sceneLoaded(Scene scene, LoadSceneMode loadMode)
        {
            if (scene.name == _startScene)
            {
                CreateNewPlayer();
            }
        }

        private void CreateNewPlayer()
        {
            QuizPlayer = new QuizPlayer
            {
                Name = _playerNameManager.RandomizeName(nameLength),
                Score = 0
            };
            PlayerPlayed = false;
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