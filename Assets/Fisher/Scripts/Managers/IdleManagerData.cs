using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FisherMan.Managers
{
    [CreateAssetMenu(menuName = "FisherMan/Manager/IdleManagerData")]
    public class IdleManagerData : ScriptableObject
    {
        private int _lenght = 30;
        public int Length { get { return _lenght; } set { _lenght = value; } }

        private int _strength = 3;
        public int Strength { get { return _strength; } set { _strength = value; } }
        
        private int _offlineEarnings = 3;
        public int OfflineEarnings { get { return _offlineEarnings; } set { _offlineEarnings = value; } } 
        
        private int _lengthCost;
        public int LengthCost { get { return _lengthCost; } set { _lengthCost = value; } }

        private int _strengthCost;
        public int StrengthCost { get { return _strengthCost; } set { _strengthCost = value; } }

        private int _offlineEarningsCost;
        public int OfflineEarningsCost { get { return _offlineEarningsCost; } set { _offlineEarningsCost = value; } }

        private int _wallet = 0;
        public int Wallet { get { return _wallet; } set { _wallet = value; } }

        private int _totalGain;
        public int TotalGain { get { return _totalGain; } set { _totalGain = value; } }

        //will chance
        [SerializeField] private int[] _uprageCostArray;
        public int[] UprageCostArray { get { return _uprageCostArray; } }

        public void StartIdleData()
        {
            _lengthCost = _uprageCostArray[_lenght / 10 - 3];
            _strengthCost = _uprageCostArray[_strength - 3];
            _offlineEarningsCost = _uprageCostArray[_offlineEarnings - 3];
        }


    }

}
