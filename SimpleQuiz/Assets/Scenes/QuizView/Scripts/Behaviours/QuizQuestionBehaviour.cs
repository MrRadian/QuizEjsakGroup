using TMPro;
using UnityEngine;

namespace Assets.Scenes.QuizView.Scripts.Behaviours
{
    public class QuizQuestionBehaviour : MonoBehaviour
    {
        [SerializeField] private TMP_Text question;
        public string Question
        {
            get { return question.text; }
            set { question.text = value; }
        }
    }
}