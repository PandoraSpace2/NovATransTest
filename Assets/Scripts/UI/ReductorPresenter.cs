using System;

namespace UI
{
    public class ReductorPresenter
    {
        private readonly ReductorModel _model;
        private readonly ReductorView _view;

        public event Action ApproachEvent;
        public event Action EstrangementEvent;

        public ReductorPresenter(ReductorModel model, ReductorView view)
        {
            _model = model;
            _view = view;
        }
        
        public void OnButtonClick(int id)
        {
            if (id == _model.SelectedId && _model.State == ReductorState.Approach)
            {
                EstrangementComponent();
            }
            else
            {
                ApproachComponent(id);
            }
        }

        private void ApproachComponent(int id)
        {
            _model.SelectedId = id;
            _view.ShowOneComponent(id);
            _model.State = ReductorState.Approach;
            ApproachEvent?.Invoke();
        }

        public void EstrangementComponent()
        {
            _view.ShowAllComponents(true);
            _model.SelectedId = -1;
            _model.State = ReductorState.Estrangement;
            EstrangementEvent?.Invoke();
        }
    }
}