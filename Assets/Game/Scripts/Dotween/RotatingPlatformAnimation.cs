using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Runner.Anim
{
    public class RotatingPlatformAnimation : MonoBehaviour
    {
        [Tooltip("checked = rotateRight / unchecked = rotateLeft ")]
        [SerializeField] private bool rotateRight = false;
        [SerializeField] private float _cycleLength = 2f;
        private void Start() 
        {
            if(rotateRight == true)
            {
                transform.DORotate(new Vector3(0,0,-360), _cycleLength, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1,LoopType.Restart);
            }
            else
            {
                transform.DORotate(new Vector3(0,0,360), _cycleLength, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1,LoopType.Restart);
            }
            
        }
    }
}
