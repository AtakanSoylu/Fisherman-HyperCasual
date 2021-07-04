using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace FisherMan.Fish
{
    public class FishController : MonoBehaviour
    {
        [SerializeField] private CircleCollider2D _circleColl;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        private float _screenLeft;

        private Tweener _tweener;

        private FishType _fishType;
        public FishType fishType
        {
            get
            {
                return _fishType;
            }
            set
            {
                _fishType = value;
                _circleColl.radius = _fishType.colliderRadius;
                _spriteRenderer.sprite = _fishType.sprite;
            }
        }

        private void Awake()
        {
            _screenLeft = Camera.main.ScreenToWorldPoint(Vector3.zero).x;

        }




        public void ResetFish()
        {
            if (_tweener != null) _tweener.Kill();

            //Random float for fish y cord
            float num = UnityEngine.Random.Range(_fishType.minLenght, _fishType.maxLenght);
            _circleColl.enabled = true;

            Vector3 position = transform.position;
            position.y = num;
            position.x = _screenLeft;
            transform.position = position;

            float num2 = 1;
            float y = UnityEngine.Random.Range(num - num2, num + num2);
            Vector2 v = new Vector2(-position.x, y);

            float num3 = 3;
            float delay = UnityEngine.Random.Range(0, 2 * num3);
            _tweener = transform.DOMove(v, num3, false).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear).SetDelay(delay).OnStepComplete(delegate
            {
                Vector3 localScale = transform.localScale;
                localScale.x = -localScale.x;
                transform.localScale = localScale;
            });

        }

        public void Hooked()
        {
            _circleColl.enabled = false;
            _tweener.Kill();
        }


        [Serializable]
        public class FishType
        {
            public int price;
            public float fishCount;
            public float minLenght;
            public float maxLenght;
            public float colliderRadius;
            public Sprite sprite;
        }
    }
}
