using System.Collections;
using System.Collections.Generic;
using Runner.Control;
using UnityEngine;

public class RankTracker : MonoBehaviour
{
    List<Competitor> competitors = new List<Competitor>();
    List<float> competitorPositions = new List<float>();
    
    private int _competitorCount;
    private int _playersRank;
    public int competitorCount {get {return _competitorCount;}}
    public int playersRank {get {return _playersRank;}}
    
    Transform playerTransform;
    

    void Start()
    {
        playerTransform = FindObjectOfType<PlayerController>().transform;
        foreach (var competitor in FindObjectsOfType<Competitor>())
        {
            competitors.Add(competitor);
        }
        _competitorCount = competitors.Count;
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
                _playersRank = (10-i);
            }
        }
    }

    private float GetCompetitorPosition(Competitor competitor)
    {
        return competitor.transform.position.z;
    }
}
