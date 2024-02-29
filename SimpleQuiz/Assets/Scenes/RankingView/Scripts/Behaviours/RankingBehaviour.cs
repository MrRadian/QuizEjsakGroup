using Assets.Scenes.SplashView.Scripts.Behaviours;
using Assets.Scripts.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace Assets.Scenes.RankingView.Scripts.Behaviours
{
    public class RankingBehaviour : MonoBehaviour
    {
        [Min(3)]
        [SerializeField] private int playerListLength = 3;

        [SerializeField] private RankingListBehaviour rankingList;

        private const string _rankingFile = "ranking.json";
        private QuizRanking _quizRanking;

        private void Awake()
        {
            var rankingFile = Path.Combine(Application.streamingAssetsPath, _rankingFile);
            GetRankingList(rankingFile);
            var player = FindObjectOfType<PlayerBehaviour>();
            if (player != null && player.PlayerPlayed)
            {
                _quizRanking.Players.Add(player.QuizPlayer);
            }
            SortAndTrimPlayer();
            rankingList.PopulateRankingList(_quizRanking.Players);
            SaveRanking(rankingFile);
        }

        private void SaveRanking(string path)
        {
            var json = JsonConvert.SerializeObject(_quizRanking);
            File.WriteAllText(path, json);
        }

        private void SortAndTrimPlayer()
        {
            _quizRanking.Players = _quizRanking.Players.OrderByDescending(score => score.Score).Take(playerListLength).ToList();
        }

        private void GetRankingList(string path)
        {
            if (File.Exists(path))
            {
                var json = File.ReadAllText(path);
                _quizRanking = JsonConvert.DeserializeObject<QuizRanking>(json);
            }
            else
            {
                _quizRanking = new QuizRanking { Players = new List<QuizPlayer>() };
            }
        }
    }
}