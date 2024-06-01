using Configs;
using UnityEngine;

public class CameraHandler : IUpdate
{
	private readonly Transform _cam;
	private readonly Transform _target;
	private readonly float _sensitivity;
	private readonly float _speedApproach;
	private Vector3 _offset;
	private float _x, _y, _minZ, _maxZ;
	private int _direction;

	private const float Y_CLAMP = 90f;

	public CameraHandler(Transform cam, Transform target, CameraConfig config)
	{
		_cam = cam;
		_target = target;
		_offset = config.Offset;
		_sensitivity = config.Sensitivity;
		_speedApproach = config.SpeedApproach;
		_minZ = _offset.z + config.Approach;
		_maxZ = _offset.z;
		_cam.position = _target.position + _offset;
	}

	public void Update()
	{
		Tracking();
		Approach();
		Estrangement();

		_offset.z = Mathf.Clamp(_offset.z, _maxZ, _minZ);
		
		CheckZ();
	}

	public void StartApproach()
	{
		_direction = -1;
	}

	public void StartEstrangement()
	{
		_direction = 1;
	}

	private void Tracking()
	{
		_x = _cam.localEulerAngles.y + Input.GetAxis("Mouse X") * _sensitivity;
		_y += Input.GetAxis("Mouse Y") * _sensitivity;
		_y = Mathf.Clamp(_y, -Y_CLAMP, Y_CLAMP);

		_cam.localEulerAngles = new Vector3(-_y, _x, 0);
		_cam.position = _cam.localRotation * _offset + _target.position;
	}

	private void Approach()
	{
		if (_direction != -1) return;

		_offset.z = Mathf.Lerp(_offset.z, _minZ, Time.deltaTime * _speedApproach);
	}

	private void Estrangement()
	{
		if (_direction != 1) return;

		_offset.z = Mathf.Lerp(_offset.z, _maxZ, Time.deltaTime * _speedApproach);
	}

	private void CheckZ()
	{
		if (_offset.z <= _maxZ || _offset.z >= _minZ)
		{
			_direction = 0;
		}
	}
}