using Assets.Scripts.Models;
using System.Text;
using UnityEngine;

namespace Assets.Scenes.SplashView.Scripts.Behaviours
{
    public class PlayerBehaviour : MonoBehaviour
    {
        [Min(2)]
        [SerializeField] private int nameLength = 5;
        private const string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public QuizPlayer QuizPlayer { get; private set; }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            CreateNewPlayer();
        }

        public void CreateNewPlayer()
        {
            QuizPlayer = new QuizPlayer
            {
                Name = RandomizeName(),
                Score = 0
            };
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
            QuizPlayer.Score += change;
            if (QuizPlayer.Score < 0)
            {
                QuizPlayer.Score = 0;
            }
        }
    }
}