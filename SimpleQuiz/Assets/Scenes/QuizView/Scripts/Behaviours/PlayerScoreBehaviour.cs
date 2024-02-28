using Assets.Scenes.SplashView.Scripts.Behaviours;
using TMPro;
using UnityEngine;

namespace Assets.Scenes.QuizView.Scripts.Behaviours
{
    public class PlayerScoreBehaviour : MonoBehaviour
    {
        [SerializeField] private TMP_Text score;
        private PlayerBehaviour _playerBehaviour;

        private void Awake()
        {
            _playerBehaviour = FindAnyObjectByType<PlayerBehaviour>();
        }
        public void UpdateScore()
        {
            score.text = _playerBehaviour.QuizPlayer.Score.ToString();
        }
    }
}