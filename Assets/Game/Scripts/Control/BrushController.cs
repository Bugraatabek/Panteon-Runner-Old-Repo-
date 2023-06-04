using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Runner.Control
{
    public class BrushController : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private Color _brushColor = Color.blue;
        [SerializeField] private float _brushSize = 0;
        [SerializeField] private bool _paintingPhase = false;
        [SerializeField] Slider _mainSlider;
        

        private void Start() 
        {
            PhaseManager.onPaintingPhaseStart += StartPainting;
        }

        private void FixedUpdate() 
        {
            if(!_paintingPhase) return;
            RaycastHit[] hits;
            Ray mousePosition = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(_mainSlider != null)
            {
                _brushSize = _mainSlider.value;
            }
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
        }

        private void StartPainting()
        {
            _paintingPhase = true;
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
    }




    
}
