using TMPro;
using UnityEngine;

public class RankUI : MonoBehaviour 
{
    [SerializeField] TextMeshProUGUI rankText;
    private void FixedUpdate() 
    {
        rankText.text = $"Rank: {RankTracker.GetPlayersRank()} / {RankTracker.GetTotalCompetitorCount()}";
    }    
}