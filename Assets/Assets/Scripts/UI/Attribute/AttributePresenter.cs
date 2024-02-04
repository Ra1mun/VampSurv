
public class AttributePresenter
{
    private readonly Attributes _model;
    private readonly AttributeView _view;
    private readonly PlayerLevelObserver _observer;
    
    public AttributePresenter(
        Attributes model,
        AttributeView view,
        PlayerLevelObserver observer)
    {
        _model = model;
        _view = view;
        _observer = observer;
    }
    public void Enable()
    {
        _observer.OnAttributeSelectionEvent += AttributeLevelChangedEvent;
    }

    private void AttributeLevelChangedEvent()
    {
        _view.OnAttributeLevelClickEvent += OnAttributeLevelClickEvent;
        _view.Open();
    }
    
    private void OnAttributeLevelClickEvent(AttributeType type)
    {
        _view.OnAttributeLevelClickEvent -= OnAttributeLevelClickEvent;
        _view.Close();
        _model.AttributeLevelUp(type);
    }
    
    public void Disable()
    {
        _observer.OnAttributeSelectionEvent -= AttributeLevelChangedEvent;
    }
}
