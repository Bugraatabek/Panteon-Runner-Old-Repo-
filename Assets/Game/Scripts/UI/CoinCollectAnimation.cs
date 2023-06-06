using UnityEngine;
using DG.Tweening;
using Runner.Collisions;
using System;
using Runner.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Pool;

namespace Runner.UI
{
    public class CoinCollectAnimation : MonoBehaviour 
    {
        private int _coinCount = 5;
        [SerializeField] Transform destination;
        [SerializeField] private Vector3 startingPosition;
        private IObjectPool<UICoin> coinPool;
        [SerializeField] UICoin uiCoin;


        private void OnEnable() 
        {
            CoinCollisionHandler.onCoinCollect += StartAnimation;
        }

        private void Awake() 
        {
            coinPool = new ObjectPool<UICoin>(CreateCoin,OnGet,OnRelease, maxSize: 15);
        }

        private UICoin CreateCoin()
        {
            return Instantiate(uiCoin,startingPosition,Quaternion.identity,transform);
        }

        private void OnGet(UICoin coin)
        {
            coin.gameObject.SetActive(true);
            coin.transform.localPosition = startingPosition;
            coin.transform.DOMove(destination.position, 1f).SetEase(Ease.Linear).OnComplete(() => {coinPool.Release(coin);});
        }

        private void OnRelease(UICoin coin)
        {
            coin.gameObject.SetActive(false);
        }

        private void StartAnimation()
        {
            StartCoroutine(CoinAnimation());
        }

        private IEnumerator CoinAnimation()
        {
            while(true)
            {
                for (int i = 0; i < _coinCount; i++)
                {
                    var coin = coinPool.Get();
                    yield return new WaitForSeconds(0.1f);
                }
                yield break;
            }
        }
    }
}