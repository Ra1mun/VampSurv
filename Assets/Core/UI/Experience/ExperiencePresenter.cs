namespace Core.UI.Experience
{
    public class ExperiencePresenter
    {
        private readonly Player.Experience.Experience _model;
        private readonly ExperienceView _view;

        public ExperiencePresenter(Player.Experience.Experience model, ExperienceView view)
        {
            _model = model;
            _view = view;
        }

        public void Enable()
        {
            _model.OnExperienceChangedEvent += OnExperienceChanged;
        }

        private void OnExperienceChanged(int currentExperience, int maxExperience)
        {
            _view.UpdateExperience(currentExperience, maxExperience);
        }

        public void Disable()
        {
            _model.OnExperienceChangedEvent -= OnExperienceChanged;
        }
    }
}