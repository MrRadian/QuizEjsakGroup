using Assets.Scripts.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Assets.Scenes.QuizView.Scripts.Behaviours
{
    public class QuizBehaviour : MonoBehaviour
    {
        [SerializeField] private AnswersHolderBehaviour answersHolder;
        [SerializeField] private QuizQuestionBehaviour quizQuestion;
        private List<QuizQuestion> _questions;
        private const string _fileName = "questions.json";

        private void Start()
        {
            var file = File.ReadAllText(Path.Combine(Application.streamingAssetsPath, _fileName));
            _questions = JsonConvert.DeserializeObject<List<QuizQuestion>>(file);
            answersHolder.LoadAnswers(_questions[0].Answers);
            quizQuestion.Question = _questions[0].Question;
        }
    }
}