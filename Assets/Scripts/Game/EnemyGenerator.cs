using System;
using System.Collections.Generic;
using Lyf.ObjectPool;
using UnityEngine;
using QFramework;
using Random = UnityEngine.Random;

namespace Game
{
	public partial class EnemyGenerator : ViewController
	{
		[Tooltip("敌人波次")] public List<EnemyWave> enemyWaves = new();
		[Tooltip("敌人生成距离")] public float enemyGenerateDistance = 10f;
		
		// 属性部分
		private float _generateTimer;	// 出怪计时器
		private float _waveTimer;	// 波次计时器
		private readonly Queue<EnemyWave> _enemyWavesQueue = new();	// 敌人波次队列

		public EnemyWave CurrentEnemyWave => _enemyWavesQueue.Count == 0 ? null : _enemyWavesQueue.Peek();	// 当前波次

		// 引用部分
		private Player _player;

		private void Start()
		{
			_player = FindObjectOfType<Player>();
			foreach (var enemyWave in enemyWaves)
			{
				_enemyWavesQueue.Enqueue(enemyWave);
			}
		}
		
		private void Update()
		{
			_generateTimer += Time.deltaTime;
			_waveTimer += Time.deltaTime;
			
			// 如果该波次结束就切换到下一波
			if (CurrentEnemyWave != null && _waveTimer >= CurrentEnemyWave.waveLastTime)
			{
				_waveTimer = 0f;
				_enemyWavesQueue.Dequeue();
			}
			
			// 如果生成CD已结束就生成敌人
			if (CurrentEnemyWave != null && _generateTimer >= CurrentEnemyWave.enemyGenerateCd)
			{
				_generateTimer = 0f;
				GenerateEnemy();
			}
		}

		private void GenerateEnemy()
		{
			if (CurrentEnemyWave == null || _player == null) return;
			
			var randomRadius = Random.Range(0, 360f) * Mathf.Deg2Rad;	// 0-360°的随机角度,并转换为弧度
			var direction = new Vector3(Mathf.Cos(randomRadius), Mathf.Sin(randomRadius), 0f);	// 根据角度计算方向
			var generatePosition = _player.transform.position +  direction * enemyGenerateDistance;	// 计算生成位置
			
			ObjectPool.Instance.Allocate(CurrentEnemyWave.enemyPrefab, obj =>
			{
				obj.Position(generatePosition)
					.Show();
			});
		}
	}

	/// <summary>
	/// 敌人波次
	/// </summary>
	[Serializable]
	public class EnemyWave
	{
		[Tooltip("当前波次敌人生成CD")] public float enemyGenerateCd = 1f;
		[Tooltip("当前波次敌人Prefab")] public GameObject enemyPrefab;
		[Tooltip("当前波次持续时间")] public float waveLastTime = 10f;
	}
}
