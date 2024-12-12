using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShip.Scripts.UI
{
    public class Result : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _resultText;
        [SerializeField] private Color _winResult;
        [SerializeField] private Color _loseResult;

        private string _resultPreset;

        public int Level { private get; set; }
        public int Time { private get; set; }
        public int Score { private get; set; }
        public bool IsWin { private get; set; }

        private void Start()
        {
            _resultPreset = _resultText.text;
            SetResult();
        }

        private void SetResult()
        {
            int minute = Time / 60;
            int second = Time - minute * 60;
            string secondText = second < 10 ? "0" + second : second.ToString();
            _resultText.text = String.Format(_resultPreset, Level, $"{minute}:{secondText}", Score);

            if (IsWin)
            {
                _image.color = _winResult;
            }
            else
            {
                _image.color = _loseResult;
            }
        }
    }
}