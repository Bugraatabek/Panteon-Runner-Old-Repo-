using System.Collections;
using System.Collections.Generic;
using Runner.Control;
using UnityEngine;
using UnityEngine.UI;

namespace Runner.UI
{
    public class BrushSliderUI : MonoBehaviour
    {
        Slider _mainSlider;
        [SerializeField] Brush brush;
        
        private void Awake() 
        {
            _mainSlider = GetComponent<Slider>(); 
            // StartCoroutine(UpdateBrush());
        }

        private void Update() 
        {
            brush.ChangeBrushSize(_mainSlider.value); 
        }
        
        // private void OnEnable() 
        // {
        //     PhaseManager.onPaintingPhaseStart += StartUpdatingUI;
            
        // }

        // private void StartUpdatingUI()
        // {
        //     StartCoroutine(UpdateBrush());
        // }

        // private IEnumerator UpdateBrush()
        // {
        //     Debug.Log("You can change brushSize");
        //     while(true)
        //     {
        //         brush.ChangeBrushSize(_mainSlider.value); 
        //         yield return null;
        //     }
        // }
    }
}
