using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Control
{
    public class Brush : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private Color brushColor;

        void Update()
        {
            RaycastHit hit;
            Ray mousePosition = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(mousePosition,out hit,50f, _layerMask))
            {
                if(Input.GetMouseButton(0))
                {
                    if(!hit.transform.GetComponent<IPaintable>().IHaveBeenPainted())
                    {
                        hit.transform.GetComponent<IPaintable>().PaintMe(brushColor);
                    }
                }
            }
        }

        private IEnumerator StartPainting()
        {
            while(true)
            {
                RaycastHit hit;
                Ray mousePosition = Camera.main.ScreenPointToRay(Input.mousePosition);
                if(Physics.Raycast(mousePosition,out hit,50f, _layerMask))
                {
                    if(Input.GetMouseButton(0))
                    {
                        if(!hit.transform.GetComponent<IPaintable>().IHaveBeenPainted())
                        {
                            hit.transform.GetComponent<IPaintable>().PaintMe(brushColor);
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
                brushColor = Color.yellow;
            }
            if(colorName == "Red")
            {
                brushColor = Color.red;
            }
            if(colorName == "Blue")
            {
                brushColor = Color.blue;
            }
        } 
    }
}
