using Assets.Scripts.Models;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scenes.RankingView.Scripts.Behaviours
{
    public class RankingListBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject player;

        public void PopulateRankingList(List<QuizPlayer> players)
        {
            for (int i = 0; i < players.Count; i++)
            {
                var playerItem = Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity, transform);
                var rankedPlayer = playerItem.GetComponent<RankingPlayerBehaviour>();
                rankedPlayer.PlayerIndex = $"{i + 1}";
                rankedPlayer.PlayerName = players[i].Name;
                rankedPlayer.PlayerScore = players[i].Score.ToString();
            }
        }
    }
}