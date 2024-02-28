using TMPro;
using UnityEngine;

namespace Assets.Scenes.QuizView.Scripts.Behaviours
{
    public class AnswerBehaviour : MonoBehaviour
    {
        [SerializeField] private TMP_Text answer;
        public string Answer
        {
            get { return answer.text; }
            set { answer.text = value; }
        }

        public int AnswerWeight { get; set; }
    }
}