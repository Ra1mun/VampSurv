public class AttributePresenter
{
    private readonly Attributes _model;
    private readonly AttributeView _view;

    public void Enable()
    {
        _view.OnUpLevelAttribute += OnUpLevelAttribute;
        _model.OnUpLevel += OnUpLevel;
    }

    private void OnUpLevel()
    {
        _view.Open();
    }
    
    private void OnUpLevelAttribute(AttributeType type)
    {
        _model.AttributeLevelUp(type);
        _view.Close();
    }
    
    public void Disable()
    {
        _view.OnUpLevelAttribute -= OnUpLevelAttribute;
        _model.OnUpLevel -= OnUpLevel;
    }
}
