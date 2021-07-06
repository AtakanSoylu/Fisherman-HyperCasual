using System;
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

        private void OnApplicationPause(bool paused)
        {
            if (paused)
            {
                DateTime now = DateTime.Now;
                Debug.Log(now.ToString());
            }
            else
            {
                string @dateTimeString = _idleManagerData.DateTime;
                if (@dateTimeString != string.Empty)
                {
                    DateTime dateTime = DateTime.Parse(@dateTimeString);
                    _idleManagerData.TotalGain = (int)((DateTime.Now - dateTime).TotalMinutes * _idleManagerData.OfflineEarnings + 1.0f);
                    ScreenManager.Instance.ChangeScreen(Screens.RETURN);
                }
            }
        }

        private void OnApplicationQuit()
        {
            OnApplicationPause(true);
        }

        //FOR BUY LENGTH BUTTON
        public void BuyLength()
        {
            _idleManagerData.Length -= 10;
            _idleManagerData.Wallet -= _idleManagerData.LengthCost;
            _idleManagerData.LengthCost = _idleManagerData.UprageCostArray[-_idleManagerData.Length / 10 - 3];
            ScreenManager.Instance.ChangeScreen(Screens.MAIN);
        }

        //FOR BUY STRENGTH BUTTON
        public void BuyStrength()
        {
            _idleManagerData.Strength++;
            _idleManagerData.Wallet -= _idleManagerData.StrengthCost;
            _idleManagerData.StrengthCost = _idleManagerData.UprageCostArray[_idleManagerData.Strength - 3];
            ScreenManager.Instance.ChangeScreen(Screens.MAIN);
        }

        //FOR BUY OFFLINE EARNING BUTTON
        public void BuyOfflineEarnings()
        {
            _idleManagerData.OfflineEarnings++;
            _idleManagerData.Wallet -= _idleManagerData.OfflineEarningsCost;
            _idleManagerData.OfflineEarningsCost = _idleManagerData.UprageCostArray[_idleManagerData.OfflineEarnings - 3];
            ScreenManager.Instance.ChangeScreen(Screens.MAIN);
        }

        public void CollectMoney()
        {
            _idleManagerData.Wallet += _idleManagerData.TotalGain;
            ScreenManager.Instance.ChangeScreen(Screens.MAIN);
        }

        public void CollectDoubleMoney()
        {
            _idleManagerData.Wallet += _idleManagerData.TotalGain * 2;
            ScreenManager.Instance.ChangeScreen(Screens.MAIN);
        }

    }
}