using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Painting
{
    public class Paintable : MonoBehaviour, IPaintable
    {
        MeshRenderer meshRenderer;
        Color startColor;
        public static event Action onPaint;
        private void Awake() 
        {
            meshRenderer = GetComponent<MeshRenderer>();
            startColor = GetComponent<MeshRenderer>().material.color;
        }

        public bool IHaveBeenPainted()
        {
            if(meshRenderer.material.color != startColor)
            {
                return true;
            }
            return false;
        }

        public void PaintMe(Color color)
        {
            if(onPaint!= null)
            {
                onPaint();
            }
            meshRenderer.material.color = color;
        }
    }
}
