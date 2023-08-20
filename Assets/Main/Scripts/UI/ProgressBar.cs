using UnityEngine;
using UnityEngine.UI;

namespace Main.Scripts.UI
{
    public class ProgressBar : MonoBehaviour
    {
        private Image _progressBarFill;

        private void Awake()
        {
            _progressBarFill = GetComponent<Image>();
        }

        public void UpdateFraction(float fraction)
        {
            _progressBarFill.fillAmount = Mathf.Clamp(fraction / 0.9f, 0, 1);
        }
    }
}