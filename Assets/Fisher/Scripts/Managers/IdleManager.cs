using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FisherMan.Managers
{
    public class IdleManager : MonoBehaviour
    {

        [SerializeField] private IdleManagerData _idleManagerData;

        private static IdleManager instance;
        public static IdleManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameObject("IdleManager").AddComponent<IdleManager>();
                }
                return instance;
            }
        }

        private void Awake()
        {
            _idleManagerData.StartIdleData();
        }

    }
}