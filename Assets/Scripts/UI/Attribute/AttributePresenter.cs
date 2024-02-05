using Assets.Scripts.Player;
using Assets.Scripts.Player.Attribute;
using Player;

namespace Assets.Scripts.UI.Attribute
{
    public class AttributePresenter
    {
        private readonly Attributes _model;
        private readonly AttributeView _view;
        private readonly PlayerLevelObserver _observer;
        private readonly UIPanelController _uiPanelController;

        public AttributePresenter(
            Attributes model,
            AttributeView view,
            PlayerLevelObserver observer,
            UIPanelController uiPanelController)
        {
            _model = model;
            _view = view;
            _observer = observer;
            _uiPanelController = uiPanelController;
        }
        public void Enable()
        {
            _observer.OnAttributeSelectionEvent += AttributeLevelChangedEvent;
        }

        private void AttributeLevelChangedEvent()
        {
            _view.OnAttributeButtonClickEvent += AttributeButtonClickEvent;
            _uiPanelController.Show(_view);
        }
    
        private void AttributeButtonClickEvent(AttributeType type)
        {
            _view.OnAttributeButtonClickEvent -= AttributeButtonClickEvent;
            _uiPanelController.Close(_view);
            _model.AttributeLevelUp(type);
        }
    
        public void Disable()
        {
            _observer.OnAttributeSelectionEvent -= AttributeLevelChangedEvent;
        }
    }
}
