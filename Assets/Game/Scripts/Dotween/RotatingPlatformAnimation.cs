using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Runner.Anim
{
    public class RotatingPlatformAnimation : MonoBehaviour
    {
        [SerializeField] private float _cycleLength = 2f;
        private void Start() 
        {
            transform.DORotate(new Vector3(0,0,360), _cycleLength, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1,LoopType.Restart);
        }
    }
}
