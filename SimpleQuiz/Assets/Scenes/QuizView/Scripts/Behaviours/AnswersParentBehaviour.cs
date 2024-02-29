using Assets.Scripts.Models;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scenes.QuizView.Scripts.Behaviours
{
    public class AnswersParentBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject answer;

        public void LoadAnswers(List<QuizAnswer> quizAnswers)
        {
            ClearAnswers();
            while (quizAnswers.Count > 0)
            {
                var answerBtn = Instantiate(answer, new Vector3(0, 0, 0), Quaternion.identity, transform);
                var answerBehaviour = answerBtn.GetComponent<AnswerButtonBehaviour>();
                var quizAnswer = quizAnswers[Random.Range(0, quizAnswers.Count)];
                answerBehaviour.Answer = quizAnswer.Answer;
                answerBehaviour.AnswerWeight = quizAnswer.AnswerWeight;
                quizAnswers.Remove(quizAnswer);
            }
        }

        private void ClearAnswers()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}