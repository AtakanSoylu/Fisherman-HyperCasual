using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FisherMan.PlayerInput
{
    [CreateAssetMenu(menuName = "FisherMan/Input/Input Data")]
    public class InputData : ScriptableObject
    {
        //Clicked mouse
        public bool FishingClick;


        [Header("Click Base Control")]
        [SerializeField] private bool _clickBaseFishingActive;
        [SerializeField] private int FishingClickButtonID;

        public void ProcessInput()
        {
            if (_clickBaseFishingActive)
            {
                bool positiveActive = Input.GetMouseButton(FishingClickButtonID);
                
                if (positiveActive)
                {
                    FishingClick = true;
                }
                else
                {
                    FishingClick = false;
                }

            }
        }


    }
}
