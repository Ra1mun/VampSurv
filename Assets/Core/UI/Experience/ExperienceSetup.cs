using UnityEngine;

namespace Core.UI
{
    public class ExperienceSetup : MonoBehaviour
    {
        [SerializeField] private Player.Experience.Experience experience;
        [SerializeField] private ExperienceView experienceView;
        
        private ExperiencePresenter experiencePresenter;
        
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