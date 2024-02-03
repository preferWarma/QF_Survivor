using DG.Tweening;
using UnityEngine;
using QFramework;

namespace Game
{
    public class CameraController : ViewController
    {
        [Tooltip("跟随目标")] public Transform follow;
        [Tooltip("镜头平滑度")] public float smooth = 10f;
        [Tooltip("震动时间")] public float shakeTime = 0.2f;
        
        private static CameraController _instance;
        private static Camera _camera;
        private static bool _isShaking;

        private void Start()
        {
            _instance = this;
            _camera = GetComponent<Camera>();
            _isShaking = false;
        }

        private void Update()
        {
            if (_isShaking) return;
            var followPosition = follow.position;
            var cameraPos = _camera.transform.position;
            var targetPos = new Vector3(followPosition.x, followPosition.y, cameraPos.z); // 2D画面保持镜头的z轴不变
            transform.position = Vector3.Lerp(cameraPos, targetPos, 1 - Mathf.Exp(-Time.deltaTime * smooth));
        }

        public static void Shake(ShakeType shakeType)
        {
            _isShaking = true;
            var strength = shakeType switch
            {
                ShakeType.Heavy => 0.4f,
                ShakeType.Middle => 0.2f,
                ShakeType.Light => 0.1f,
                _ => 0f
            };

            // 参数分别为：震动时间，震动幅度，震动次数，震动角度，是否随机角度，是否把初始位置作为震动的一部分，震动的随机性(枚举)
            _camera.transform.DOShakePosition(_instance.shakeTime, strength, 100, 180, false, true,
                ShakeRandomnessMode.Harmonic)
                .OnComplete(() => { _isShaking = false;});
        }
    }

    public enum ShakeType
    {
        Heavy,
        Middle,
        Light
    }
}