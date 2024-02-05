using UnityEngine;

namespace Assets.Scripts.UI.Experience
{
    public class ExperienceSetup : MonoBehaviour
    {
        [SerializeField] Player.Experience.Experience experience;
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
}
