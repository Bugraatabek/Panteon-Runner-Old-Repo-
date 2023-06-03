using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Runner.Anim
{
    public class HalfDonutAnimation : MonoBehaviour
    {
        [SerializeField] private Transform _movingStick;
        [SerializeField] private float _cycleLength = 2;
        void Start()
        {
            _movingStick.DOLocalMoveX(0.15f,_cycleLength).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
        }
    }
}

