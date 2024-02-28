using Assets.Scripts.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Assets.Scenes.QuizView.Scripts.Behaviours
{
    public class QuizBehaviour : MonoBehaviour
    {
        private List<QuizQuestion> _questions;
        private const string _fileName = "questions.json";

        private void Start()
        {
            var file = File.ReadAllText(Path.Combine(Application.streamingAssetsPath, _fileName));
            _questions = JsonConvert.DeserializeObject<List<QuizQuestion>>(file);
        }
    }
}