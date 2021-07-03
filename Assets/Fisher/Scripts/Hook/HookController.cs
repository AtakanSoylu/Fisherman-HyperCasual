using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using FisherMan.PlayerInput;

namespace FisherMan.Hook
{
    public class HookController : MonoBehaviour
    {
        [SerializeField] private HookControllerSettings _hookControllerSettings;
        [SerializeField] private InputData _inputData;
        [SerializeField] private Transform _hookedTransform;
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private Collider2D _colider2D;


        private Tweener _cameraTween;

        private bool canMove = true;



        private void Update()
        {
            if(canMove && _inputData.FishingClick)
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
            float time = (-_hookControllerSettings.Length) * 0.1f;
        }
    }
}
