using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Runner.Anim
{
    public class RotatingStickAnimation : MonoBehaviour
    {
        [SerializeField] private Transform _rotatingStick;
        [SerializeField] private float _cycleLength = 2f;
        
        void Start()
        {
            Quaternion targetRotation = Quaternion.Euler(0f,359f,0f);
            _rotatingStick.DOLocalRotate(targetRotation.eulerAngles, _cycleLength, RotateMode.LocalAxisAdd).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
        }
    }
}
