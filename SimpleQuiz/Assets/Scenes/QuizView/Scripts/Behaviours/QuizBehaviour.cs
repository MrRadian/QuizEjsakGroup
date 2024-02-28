using Assets.Scripts.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scenes.QuizView.Scripts.Behaviours
{
    public class QuizBehaviour : MonoBehaviour
    {
        [SerializeField] private AnswersParentBehaviour answersParent;
        [SerializeField] private QuizQuestionBehaviour quizQuestion;
        private List<QuizQuestion> _questions;
        private int _index;
        private const string _fileName = "questions.json";

        private void Start()
        {
            var filePath = Path.Combine(Application.streamingAssetsPath, _fileName);
            if (!File.Exists(filePath))
            {
                Debug.Log($"Missing question file. Path to file {filePath}");
                return;
            }
            var json = File.ReadAllText(filePath);
            _questions = JsonConvert.DeserializeObject<List<QuizQuestion>>(json);
            LoadQuestions();
        }

        public void LoadQuestions()
        {
            if (_index >= _questions.Count) //mo¿na dodaæ pobieranie z stosu, aby nie losowaæ dwukrotnie tego samego pytania
            {
                EndGame();
                return;
            }
            answersParent.LoadAnswers(_questions[_index].Answers);
            quizQuestion.Question = _questions[_index].Question;
            _index++;
        }

        private void EndGame()
        {
            SceneManager.LoadScene("RankingView");
        }
    }
}