

public class AttributePresenter
{
    private readonly Attributes _model;
    private readonly AttributeView _view;
    
    public AttributePresenter(Attributes model, AttributeView view)
    {
        _model = model;
        _view = view;
    }
    public void Enable()
    {
        _view.OnAttributeLevelClickEvent += OnAttributeLevelClickEvent;
        _model.OnLevelUp += OnLevelUp;
    }

    private void OnLevelUp()
    {
        _view.Open();
    }
    
    private void OnAttributeLevelClickEvent(AttributeType type)
    {
        _model.AttributeLevelUp(type);
        _view.Close();
    }
    
    public void Disable()
    {
        _view.OnAttributeLevelClickEvent -= OnAttributeLevelClickEvent;
        _model.OnLevelUp -= OnLevelUp;
    }
}
