using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Runner.Anim
{
    public class ShiningObstacleAnimation : MonoBehaviour
    {
        [SerializeField] private float _cycleLength = 2f;
        [SerializeField] private float _xAxisMoveLength = 2f;
        [SerializeField] private Transform _shiningObstacle;
        void Start()
        {
            _shiningObstacle.DOLocalRotate(new Vector3(0,360,0),_cycleLength, RotateMode.FastBeyond360).SetLoops(-1,LoopType.Restart).SetEase(Ease.Linear);
            transform.DOLocalMoveX(_xAxisMoveLength, _cycleLength).SetEase(Ease.Linear).SetLoops(-1,LoopType.Yoyo);
        }
    }
}
