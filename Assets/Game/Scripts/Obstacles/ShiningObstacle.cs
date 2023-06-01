using UnityEngine;

namespace Runner.Obstacles
{
    public class ShiningObstacle : MonoBehaviour, ISpecialObstacle
    {
        [SerializeField] ParticleSystemRenderer particleSystemRenderer;
        private Color[] colors = new Color[4];

        private void Awake() 
        {
            colors[0] = Color.yellow;
            colors[1] = Color.blue;
            colors[2] = Color.red;
            colors[3] = Color.green;
        }

        public void OnCollisionLogic(GameObject competitor)
        {
            Color randomColor = colors[Random.Range(0,4)];
            particleSystemRenderer.material.color = randomColor;
            
        }
    }
}