using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using FisherMan.PlayerInput;
using FisherMan.Fish;
using System;
using FisherMan.Managers;

namespace FisherMan.Hook
{
    public class HookController : MonoBehaviour
    {
        //[SerializeField] private HookControllerSettings _hookControllerSettings;
        [SerializeField] private IdleManagerData _idleManagerData;
        [SerializeField] private InputData _inputData;
        [SerializeField] private Transform _hookedTransform;
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private Collider2D _colider2D;


        //DOTween Adjusting
        private Tweener _cameraTween;
        private Sequence _sequence;


        private bool _canMove = true;
        private int _fishCount;

        private List<FishController> _hookedFishList;


        private void Awake()
        {
            _hookedFishList = new List<FishController>();
        }

        private void Update()
        {
            if (_canMove && _inputData.FishingClick)
            {
                float mouseXPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition).x;
                TransformMoveX(mouseXPosition);
            }
        }

        public void TransformMoveX(float mouseXPosition)
        {
            transform.position = new Vector3(mouseXPosition, transform.position.y, transform.position.x);
        }

        public void StartFishing()
        {

            int length = _idleManagerData.Length - 20;
            int strength = _idleManagerData.Strength;
            _fishCount = 0; 


            float timeMultiplier = 0.1f;
            float time = (-length) * timeMultiplier;

            _cameraTween = _mainCamera.transform.DOMoveY(length, 1 + time * 0.25f, false).OnUpdate(delegate
            {
                float exitYCord = -11f;
                if (_mainCamera.transform.position.y <= exitYCord)
                    transform.SetParent(_mainCamera.transform);
            }).OnComplete(delegate
            {
                _colider2D.enabled = true;
                _cameraTween = _mainCamera.transform.DOMoveY(0, time * 5, false).OnUpdate(delegate
                    {
                        float endYCord = -25f;
                        if (_mainCamera.transform.position.y >= endYCord)
                        {
                            StopFishing();
                        }
                    });


            });

            ScreenManager.Instance.ChangeScreen(Screens.GAME);
            _colider2D.enabled = false;
            _canMove = true;
            _hookedFishList.Clear();
        }

        private void StopFishing()
        {
            _canMove = false;
            _cameraTween.Kill(false);
            _cameraTween = _mainCamera.transform.DOMoveY(0, 2, false).OnUpdate(delegate
            {
                float bottomEntryYcord = -11f;
                float defaultYCord = -6;

                if (_mainCamera.transform.position.y >= bottomEntryYcord)
                {
                    transform.SetParent(null);
                    transform.position = new Vector2(transform.position.x, defaultYCord);
                }
            }).OnComplete(delegate
            {
                transform.position = Vector2.down * 6;
                _colider2D.enabled = true;
                int num = 0;
                for (int i = 0; i < _hookedFishList.Count; i++)
                {
                    _hookedFishList[i].transform.SetParent(null);
                    _hookedFishList[i].ResetFish();
                    num += _hookedFishList[i].fishType.price;
                }
                _idleManagerData.TotalGain = num;
                ScreenManager.Instance.ChangeScreen(Screens.END);
            });



        }

        private void OnTriggerEnter2D(Collider2D target)
        {
            FishController fish = target.GetComponent<FishController>();
            if (fish != null)
            {
                int length = _idleManagerData.Length - 20;
                int strength = _idleManagerData.Strength;
                if (_idleManagerData.Strength != _fishCount)
                {
                    _fishCount++;
                    fish.Hooked();
                    _hookedFishList.Add(fish);
                    fish.transform.SetParent(transform);
                    fish.transform.position = _hookedTransform.position;
                    fish.transform.rotation = _hookedTransform.rotation;
                    fish.transform.localScale = Vector3.one;

                    fish.transform.DOShakeRotation(5, Vector3.forward * 45, 10, 90, false).SetLoops(1, LoopType.Yoyo).OnComplete(delegate
                    {
                        fish.transform.rotation = Quaternion.identity;
                    });
                    if (_fishCount == _idleManagerData.Strength)
                    {
                        StopFishing();
                    }

                }
            }
        }


    }
}
