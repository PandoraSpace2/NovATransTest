using System;
using Configs;
using UI;
using UnityEngine;

public class MainBootstrap : MonoBehaviour
{
    [SerializeField] private Updater _updater;
    [SerializeField] private MainConfigs _configs;
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _reductor;
    [SerializeField] private ReductorView _reductorView;

    private ReductorPresenter _reductorPresenter;
    private CameraHandler _cameraHandler;

    private void Awake()
    {
        _cameraHandler = new CameraHandler(_camera.transform, _reductor, _configs.CameraConfig);
        _updater.Add(_cameraHandler);
        
        var reductorModel = new ReductorModel();
        _reductorPresenter = new ReductorPresenter(reductorModel, _reductorView);
        _reductorView.Init(_reductorPresenter);

        _reductorPresenter.ApproachEvent += _cameraHandler.StartApproach;
        _reductorPresenter.EstrangementEvent += _cameraHandler.StartEstrangement;
    }

    private void OnDestroy()
    {
        _reductorPresenter.ApproachEvent -= _cameraHandler.StartApproach;
        _reductorPresenter.EstrangementEvent -= _cameraHandler.StartEstrangement;
    }
}

[Serializable]
public class MainConfigs
{
    public CameraConfig CameraConfig;
}