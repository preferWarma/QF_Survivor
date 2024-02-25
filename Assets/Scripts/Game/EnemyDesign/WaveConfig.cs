using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.EnemyDesign
{
    /// <summary>
    /// 波次设计, 基于ScriptableObject设计
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableObjects/WaveDesign")]
    public class WaveConfig : ScriptableObject
    {
        [SerializeField] public List<EnemyWave> enemyWaves = new();
    }
    
    /// <summary>
    /// 敌人波次
    /// </summary>
    [Serializable]
    public class EnemyWave
    {
        [Tooltip("当前波次描述")][TextArea] public string description = string.Empty;
        [Tooltip("当前波次敌人生成CD")] public float enemyGenerateCd = 1f;
        [Tooltip("当前波次敌人Prefab")] public GameObject enemyPrefab;
        [Tooltip("当前波次持续时间")] public float waveLastTime = 10f;
        [Tooltip("生命倍率")] public float hpScale = 1f;
        [Tooltip("速度倍率")] public float speedScale = 1f;
        [Tooltip("是否激活")] public bool isActive = true;
    }
}