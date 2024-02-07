using Core.Player;
using Core.Player.Attribute;

namespace Core.UI.Attribute
{
    public class AttributePresenter
    {
        private readonly Attributes _model;
        private readonly PlayerLevelObserver _observer;
        private readonly UIPanelController _uiPanelController;
        private readonly AttributeView _view;
        private readonly TimeState _timeState;

        public AttributePresenter(
            Attributes model,
            AttributeView view,
            PlayerLevelObserver observer,
            UIPanelController uiPanelController,
            TimeState timeState)
        {
            _model = model;
            _view = view;
            _observer = observer;
            _uiPanelController = uiPanelController;
            _timeState = timeState;
        }

        public void Enable()
        {
            _observer.OnAttributeSelectionEvent += AttributeLevelChangedEvent;
            _observer.OnAttributeSelectionEvent += _timeState.Pause;
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
            _timeState.Resume();
        }

        public void Disable()
        {
            _observer.OnAttributeSelectionEvent -= AttributeLevelChangedEvent;
            _observer.OnAttributeSelectionEvent -= _timeState.Pause;
        }
    }
}