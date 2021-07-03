using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FisherMan.Hook
{
    [CreateAssetMenu(menuName = "FisherMan/Hook/Hook Controller Settings")]
    public class HookControllerSettings : ScriptableObject
    {
        [SerializeField] private float _length;
        public float Length { get { return _length; } }
        [SerializeField] private float _strength;
        public float Strength { get { return _strength; } }
        [SerializeField] private float _fishCount;
        public float FishCount { get { return _fishCount; } }

    }
}