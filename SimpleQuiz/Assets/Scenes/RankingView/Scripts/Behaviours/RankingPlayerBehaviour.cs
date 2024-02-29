using TMPro;
using UnityEngine;

namespace Assets.Scenes.RankingView.Scripts.Behaviours
{
    public class RankingPlayerBehaviour : MonoBehaviour
    {
        [SerializeField] private TMP_Text playerIndex;
        [SerializeField] private TMP_Text playerName;
        [SerializeField] private TMP_Text playerScore;

        public string PlayerIndex
        { get { return playerIndex.text; } set { playerIndex.text = value; } }

        public string PlayerName
        { get { return playerName.text; } set { playerName.text = value; } }

        public string PlayerScore
        { get { return playerScore.text; } set { playerScore.text = value; } }
    }
}