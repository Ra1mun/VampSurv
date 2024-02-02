public class ExperiencePresenter
{
    private Experience _model;
    private ExperienceView _view;

    public ExperiencePresenter(Experience model, ExperienceView view)
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
