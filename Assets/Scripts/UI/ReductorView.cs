using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class ReductorView : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _components;
        [SerializeField] private Animator _animatorReductor;
        [SerializeField] private Animator _animatorList;
        private ReductorPresenter _presenter;

        public IReadOnlyList<GameObject> Components => _components;
        
        public void Init(ReductorPresenter presenter)
        {
            _presenter = presenter;
        }

        public void OnClick(int id)
        {
            _presenter.OnButtonClick(id);
        }

        public void OnClickExplosion()
        {
            _presenter.EstrangementComponent();
            _animatorReductor.SetTrigger("Explosion");
            _animatorList.SetTrigger("List");
        }

        public void ShowAllComponents(bool isShow)
        {
            foreach (GameObject component in _components)
            {
                component.SetActive(isShow);
            }
        }

        public void ShowOneComponent(int id)
        {
            if (_components.Count > id)
            {
                ShowAllComponents(false);
                _components[id].SetActive(true);
            }
        }
    }
}