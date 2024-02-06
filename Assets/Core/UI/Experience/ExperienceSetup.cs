using UnityEngine;

namespace Core.UI.Experience
{
    public class ExperienceSetup : MonoBehaviour
    {
        [SerializeField] private Player.Experience.Experience experience;
        [SerializeField] private ExperienceView experienceView;
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
}