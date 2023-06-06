using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    public DeathTracker DeathTracker { get { return _deathTracker;} }
    public LevelBoundry LevelBoundry { get { return _levelBoundry;} }
    public PaintPercentageTracker PaintPercentageTracker { get { return _paintPercentageTracker;} } 
    public PhaseManager PhaseManager { get { return _phaseManager; } }
    public RankTracker RankTracker { get { return _rankTracker; } }
    public ScoreTracker ScoreTracker { get { return _scoreTracker; } }
    
    
    DeathTracker _deathTracker;
    LevelBoundry _levelBoundry;
    PaintPercentageTracker _paintPercentageTracker;
    PhaseManager _phaseManager;
    RankTracker _rankTracker;
    ScoreTracker _scoreTracker;
    

    public static Singleton Instance {get; private set;}
    private void Awake() 
    {
        transform.parent = null;

        if(Instance) { Destroy(gameObject); }
        else { Instance = this; }

        _deathTracker = GetComponent<DeathTracker>();
        _levelBoundry = GetComponent<LevelBoundry>();
        _paintPercentageTracker = GetComponent<PaintPercentageTracker>();
        _phaseManager = GetComponent<PhaseManager>();
        _rankTracker = GetComponent<RankTracker>();
        _scoreTracker = GetComponent<ScoreTracker>();
    }

   
}
