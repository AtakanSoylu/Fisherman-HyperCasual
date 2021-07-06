using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FisherMan.Managers
{
    public enum Screens
    {
        MAIN,
        END,
        GAME,
        RETURN
    }



    public class ScreenManager : MonoBehaviour
    {
        private static ScreenManager instance;

        private GameObject _currentScreen;

        //IdleManagerData
        [Header("IdleManagerData")]
        [SerializeField] private IdleManagerData _idleManagerData;

        //Screens
        [Header("Screens")]
        [SerializeField] public GameObject _endScreen;
        [SerializeField] public GameObject _gameScreen;
        [SerializeField] public GameObject _mainScreen;
        [SerializeField] public GameObject _returnScreen;

        //Buttons
        [Header("Buttons")]
        [SerializeField] private Button _lengthButton;
        [SerializeField] private Button _strengthButton;
        [SerializeField] private Button _offlineButton;

        //Texts
        [Header("Texts")]
        [SerializeField] private Text _gameScreenMoney;
        [SerializeField] private Text _lengthCostText;
        [SerializeField] private Text _lengthValueText;
        [SerializeField] private Text _strengthCostText;
        [SerializeField] private Text _strengthValueText;
        [SerializeField] private Text _offlineCostText;
        [SerializeField] private Text _offlineValueText;
        [SerializeField] private Text _endScreenMoney;
        [SerializeField] private Text _returnScreenMoney;

        private int _gameCount = 0;

        public static ScreenManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameObject("ScreenManager").AddComponent<ScreenManager>();
                }
                return instance;
            }
        }

        private void Awake()
        {
            if (instance)
                Destroy(gameObject);
            else
                instance = this;
            _currentScreen = _mainScreen;
        }

        private void Start()
        {
            CheckIdles();
            UpdateTexts();
        }

        public void ChangeScreen(Screens screen)
        {
            _currentScreen.SetActive(false);

            switch (screen)
            {
                case Screens.MAIN:
                    _currentScreen = _mainScreen;
                    UpdateTexts();
                    CheckIdles();
                    break;

                case Screens.GAME:
                    _currentScreen = _gameScreen;
                    _gameCount++;
                    break;

                case Screens.END:
                    _currentScreen = _endScreen;
                    SetEndScreenMoney();
                    break;

                case Screens.RETURN:
                    _currentScreen = _returnScreen;
                    SetReturnScreenMoney();
                    break;
            }

            _currentScreen.SetActive(true);
        }

        private void SetEndScreenMoney()
        {
            _endScreenMoney.text = "$" + _idleManagerData.TotalGain;
        }

        private void SetReturnScreenMoney()
        {
            _returnScreenMoney.text = "$" + _idleManagerData.TotalGain + "gained while waiting!";
        }

        private void UpdateTexts()
        {
            _gameScreenMoney.text = "$" + _idleManagerData.Wallet;
            _lengthCostText.text = "$" + _idleManagerData.LengthCost;
            _lengthValueText.text = -_idleManagerData.Length + "m";
            _strengthCostText.text = "$" + _idleManagerData.StrengthCost;
            _strengthValueText.text = _idleManagerData.Strength + "fishes.";
            _offlineCostText.text = "$" + _idleManagerData.OfflineEarningsCost;
            _offlineValueText.text = "$" + _idleManagerData.OfflineEarnings + "/min";
        }


        private void CheckIdles()
        {
            if (_idleManagerData.Wallet < _idleManagerData.LengthCost)
                _lengthButton.interactable = false;
            else
                _lengthButton.interactable = true;

            if (_idleManagerData.Wallet < _idleManagerData.StrengthCost)
                _strengthButton.interactable = false;
            else
                _strengthButton.interactable = true;


            if (_idleManagerData.Wallet < _idleManagerData.OfflineEarningsCost)
                _offlineButton.interactable = false;
            else
                _offlineButton.interactable = true;
        }
    }
}
