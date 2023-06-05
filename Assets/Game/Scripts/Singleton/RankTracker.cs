using System.Collections;
using System.Collections.Generic;
using Runner.Control;
using UnityEngine;

public class RankTracker : MonoBehaviour
{
    List<Competitor> competitors = new List<Competitor>();
    List<float> competitorPositions = new List<float>();
    public static int totalCompetitorsCount;
    public static int playersRank;
    Transform playerTransform;
    

    void Start()
    {
        playerTransform = FindObjectOfType<PlayerController>().transform;
        foreach (var competitor in FindObjectsOfType<Competitor>())
        {
            competitors.Add(competitor);
        }
        totalCompetitorsCount = competitors.Count;
    }
    
    private void FixedUpdate() 
    {
        CalculatePlayerRank();
    }

    private void CalculatePlayerRank()
    {
        competitorPositions = new List<float>();
        foreach (var competitor in competitors)
        {
            competitorPositions.Add(GetCompetitorPosition(competitor));
        }
        competitorPositions.Sort();
        
        for (int i = 0; i < competitorPositions.Count; i++)
        {
            if(competitorPositions[i] == playerTransform.position.z)
            {
                playersRank = (10-i);
            }
        }
    }

    private float GetCompetitorPosition(Competitor competitor)
    {
        return competitor.transform.position.z;
    }

   
    //Public Getters
    public static int GetTotalCompetitorCount()
    {
        return totalCompetitorsCount;
    }

    public static int GetPlayersRank()
    {
        return playersRank;
    }
}
