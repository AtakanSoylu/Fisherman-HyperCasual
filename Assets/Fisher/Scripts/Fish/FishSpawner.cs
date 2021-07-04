using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FisherMan.Fish
{
    public class FishSpawner : MonoBehaviour
    {
        [SerializeField] private Fish _fishPrefab;
        [SerializeField] private Fish.FishType[] _fishTypes;
        private void Awake()
        {
            for (int i = 0; i < _fishTypes.Length; i++)
            {
                int num = 0;
                while (num < _fishTypes[i].fishCount)
                {
                    Fish fish = Instantiate(_fishPrefab);
                    fish.fishType = _fishTypes[i];
                    fish.ResetFish();
                    num++;
                }
            }
        }



    }
}