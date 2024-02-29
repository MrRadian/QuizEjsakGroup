using Assets.Scenes.SplashView.Scripts.Behaviours;
using TMPro;
using UnityEngine;

namespace Assets.Scenes.QuizView.Scripts.Behaviours
{
    public class AnswerButtonBehaviour : MonoBehaviour
    {
        [SerializeField] private TMP_Text answer;

        public string Answer
        {
            get { return answer.text; }
            set { answer.text = value; }
        }

        public int AnswerWeight { get; set; }

        public void AddPointsToplayerScore()
        {
            FindObjectOfType<QuizBehaviour>().LoadQuestions();
            FindObjectOfType<PlayerBehaviour>().ChangeScore(AnswerWeight);
            FindObjectOfType<PlayerScoreBehaviour>().UpdateScore();
        }
    }
}