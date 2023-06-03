using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Control
{
    public class Brush : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private Color _brushColor = Color.blue;
        [SerializeField] private float _brushSize = 0;
        

        private void Start() 
        {
            PhaseManager.onPaintingPhaseStart += StartPainting;
        }

        private void StartPainting()
        {
            StartCoroutine(PaintingRoutine());
        }

        private IEnumerator PaintingRoutine()
        {
            while(true)
            {
                RaycastHit[] hits;
                Ray mousePosition = Camera.main.ScreenPointToRay(Input.mousePosition);
                hits = Physics.SphereCastAll(mousePosition,_brushSize, 50f,_layerMask);
                foreach (RaycastHit hit in hits)
                {
                    var paintable = hit.transform.GetComponent<IPaintable>();
                    if(paintable != null)
                    {
                        if(Input.GetMouseButton(0))
                        {
                            if(!paintable.IHaveBeenPainted())
                            {
                                paintable.PaintMe(_brushColor);
                            }
                        }
                        
                    }
                }
                yield return null;     
            }
        }
        
        public void SetBrushColor(String colorName)
        {
            if(colorName == "Yellow")
            {
                _brushColor = Color.yellow;
            }
            if(colorName == "Red")
            {
                _brushColor = Color.red;
            }
            if(colorName == "Blue")
            {
                _brushColor = Color.blue;
            }
        } 

        public void ChangeBrushSize(float value)
        {
            _brushSize = value;
        }
    }




    
}
