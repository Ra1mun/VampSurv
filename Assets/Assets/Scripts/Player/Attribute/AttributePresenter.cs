public class AttributePresenter
{
    private readonly Attributes _model;
    private readonly AttributeView _view;

    public void Enable()
    {
        _view.OnAttributeLevelChanged += OnAttributeLevelChanged;
        _model.OnLevelUp += OnLevelUp;
    }

    private void OnLevelUp()
    {
        _view.Open();
    }
    
    private void OnAttributeLevelChanged(AttributeType type)
    {
        _model.AttributeLevelUp(type);
        _view.Close();
    }
    
    public void Disable()
    {
        _view.OnAttributeLevelChanged -= OnAttributeLevelChanged;
        _model.OnLevelUp -= OnLevelUp;
    }
}
