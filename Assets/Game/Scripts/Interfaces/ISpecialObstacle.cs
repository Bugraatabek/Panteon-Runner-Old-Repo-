using UnityEngine;

public interface ISpecialObstacle
{
    public void OnCollisionLogic(GameObject competitor, Vector3 contactPoint);
}