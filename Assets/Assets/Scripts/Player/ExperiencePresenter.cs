public class ExperiencePresenter
{
    private Experience _model;

    public ExperiencePresenter(Experience model)
    {
        _model = model;
    }

    public void Enable()
    {
        _model.OnExpChanged += OnExpChanged;
        _model.OnLevelChanged += OnLevelChaged;
    }
    
    public void Disable()
    {
        _model.OnExpChanged -= OnExpChanged;
        _model.OnLevelChanged -= OnLevelChaged;
    }

    private void OnExpChanged(int value)
    {
        
    }

    private void OnLevelChaged()
    {
        
    }
}
