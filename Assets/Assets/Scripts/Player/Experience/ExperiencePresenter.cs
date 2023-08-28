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
        _model.OnExperienceChanged += OnExperienceChanged;
        _model.OnLevelChanged += OnLevelChaged;
    }
    
    private void OnExperienceChanged(int value)
    {
        
    }

    private void OnLevelChaged()
    {
        
    }
    
    public void Disable()
    {
        _model.OnExperienceChanged -= OnExperienceChanged;
        _model.OnLevelChanged -= OnLevelChaged;
    }

    
}
