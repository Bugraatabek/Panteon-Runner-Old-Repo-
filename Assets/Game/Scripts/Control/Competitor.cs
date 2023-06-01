using UnityEngine;

public class Competitor : MonoBehaviour, ICompetitor
{
    [SerializeField] private Transform _restartPoint;
    public void OnCollison()
    {
        transform.position = _restartPoint.position;
    }
}