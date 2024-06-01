using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "Camera", menuName = "Configs", order = 0)]
    public class CameraConfig : ScriptableObject
    {
        public Vector3 Offset;
        public float Sensitivity;
        [Range(1f, 5f)] public float Approach;
        [Range(1f, 3f)] public float SpeedApproach;
    }
}