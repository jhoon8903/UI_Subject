using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace _01.Scripts.UI.PopUp
{
    public class Intro_Popup : MonoBehaviour
    {
        [SerializeField] private Slider loadingSlider;
        [SerializeField] private TextMeshProUGUI loadingText;

        public int Count { get; set; }

        public int MaxCount { get; set; }

        private void Initialized()
        {
            loadingSlider.maxValue = MaxCount;
            loadingSlider.value = 0;
        }

        public void Loading(string key)
        {
            loadingText.text = $"{key} Load [{Count} / {MaxCount}]";
            loadingSlider.value = Count;
        }
    }
}