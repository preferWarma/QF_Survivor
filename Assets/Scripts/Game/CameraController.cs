﻿using DG.Tweening;
using UnityEngine;
using QFramework;

namespace Game
{
    public class CameraController : ViewController
    {
        [Tooltip("跟随目标")] public Transform follow;
        [Tooltip("镜头平滑度")] public float smooth = 10f;
        [Tooltip("震动时间")] public float shakeTime = 0.2f;
        
        public static Camera Camera { get; private set; }
        
        private static CameraController _instance;
        private static bool _isShaking;

        private void Start()
        {
            _instance = this;
            Camera = GetComponent<Camera>();
            _isShaking = false;
        }

        private void Update()
        {
            if (_isShaking) return;
            var followPosition = follow.position;
            var cameraPos = Camera.transform.position;
            var targetPos = new Vector3(followPosition.x, followPosition.y, cameraPos.z); // 2D画面保持镜头的z轴不变
            transform.position = Vector3.Lerp(cameraPos, targetPos, 1 - Mathf.Exp(-Time.deltaTime * smooth));
        }

        public static void Shake(ShakeType shakeType)
        {
            _isShaking = true;
            var strength = shakeType switch
            {
                ShakeType.Heavy => 0.3f,
                ShakeType.Middle => 0.15f,
                ShakeType.Light => 0.05f,
                _ => 0f
            };

            // 参数分别为：震动时间，震动幅度，震动次数，震动角度，是否随机角度，是否把初始位置作为震动的一部分，震动的随机性(枚举)
            Camera.transform.DOShakePosition(_instance.shakeTime, strength, 100, 180)
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