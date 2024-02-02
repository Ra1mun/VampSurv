using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceView : MonoBehaviour
{
    [SerializeField] private Slider _experienceBar;
    [SerializeField] private TMP_Text _text;

    public void UpdateExperience(int currentExperience, int maxExperience)
    {
        _experienceBar.value = currentExperience / 100;
        _text.text = $"{currentExperience} / {maxExperience}";
    }
    
}
