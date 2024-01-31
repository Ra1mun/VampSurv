using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceSetup : MonoBehaviour
{
    [SerializeField] Experience experience;
    [SerializeField] ExperienceView experienceView;
    private ExperiencePresenter experiencePresenter;
    private void Awake()
    {

    }
    private void OnEnable()
    {
        experiencePresenter = new ExperiencePresenter(experience, experienceView);
        experiencePresenter.Enable();

    }
    private void OnDisable()
    {
        experiencePresenter.Disable();
    }
}
