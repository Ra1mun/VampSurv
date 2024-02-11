using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.UI
{
    public class ExperienceView : MonoBehaviour
    {
        [SerializeField] private Image experienceBar;
        [SerializeField] private TMP_Text experienceText;
        public void UpdateExperience(int currentExperience, int maxExperience)
        {
            experienceBar.fillAmount = (float)currentExperience / maxExperience;
            experienceText.text = $"{currentExperience} / {maxExperience}";
        }
    }
}