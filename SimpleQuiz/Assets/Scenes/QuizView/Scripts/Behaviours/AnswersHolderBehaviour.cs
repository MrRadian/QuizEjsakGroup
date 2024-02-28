using Assets.Scripts.Models;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scenes.QuizView.Scripts.Behaviours
{
    public class AnswersHolderBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject answer;

        public void LoadAnswers(List<QuizAnswer> quizAnswers)
        {
            foreach (QuizAnswer quizAnswer in quizAnswers)
            {
                var answerBtn = Instantiate(answer, new Vector3(0, 0, 0), Quaternion.identity, transform);
                var answerBehaviour = answerBtn.GetComponent<AnswerBehaviour>();
                answerBehaviour.Answer = quizAnswer.Answer;
                answerBehaviour.AnswerWeight = quizAnswer.AnswerWeight;
            }
        }

        public void ClearAnswers()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}