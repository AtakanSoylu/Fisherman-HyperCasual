using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FisherMan.Managers
{
    [CreateAssetMenu(menuName = "FisherMan/Manager/IdleManagerData")]
    public class IdleManagerData : ScriptableObject
    {
        private int _lenght;
        public int Length { get { return _lenght; } set { _lenght = value; } }

        private int _strength;
        public int Strength { get { return _strength; } set { _strength = value; } }
        
        private int _offlineEarnings;
        public int OfflineEarnings { get { return _offlineEarnings; } set { _offlineEarnings = value; } } 
        
        private int _lengthCost;
        public int LengthCost { get { return _lengthCost; } set { _lengthCost = value; } }

        private int _strengthCost;
        public int StrengthCost { get { return _strengthCost; } set { _strengthCost = value; } }

        private int _offlineEarningsCost;
        public int OfflineEarningsCost { get { return _offlineEarningsCost; } set { _offlineEarningsCost = value; } }

        private int _wallet;
        public int Wallet { get { return _wallet; } set { _wallet = value; } }

        private int _totalGain;
        public int TotalGain { get { return _totalGain; } set { _totalGain = value; } }

    }
}
