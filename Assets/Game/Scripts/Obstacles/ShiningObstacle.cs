using UnityEngine;

namespace Runner.Obstacles
{
    public class ShiningObstacle : MonoBehaviour, ISpecialObstacle
    {
        [SerializeField] ParticleSystemRenderer particleSystemRenderer;
        private Color[] colors = new Color[4];
        private int _colorNumber;

        private void Awake() 
        {
            _colorNumber = 0;
            colors[0] = Color.yellow;
            colors[1] = Color.blue;
            colors[2] = Color.red;
            colors[3] = Color.cyan;
        }

        public void OnCollision(Rigidbody competitorRB, Vector3 contactPoint)
        {
            Color randomColor = colors[_colorNumber];
            particleSystemRenderer.material.color = randomColor;
            _colorNumber += 1;
            if(_colorNumber == 4) 
            {
                _colorNumber = 0;
            }
        }
    }
}