using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FisherMan.Hook
{
    [CreateAssetMenu(menuName = "FisherMan/Hook/Hook Controller Settings")]
    public class HookControllerSettings : ScriptableObject
    {
        [SerializeField] private float _fishCount;
        public float FishCount
        {
            get
            {
                return _fishCount;
            }
            set
            {
                _fishCount = value;
            }
        }

    }
}