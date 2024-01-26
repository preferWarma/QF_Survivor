using UnityEngine;
using QFramework;

namespace Game.Ability
{
	public partial class SampleAbility : ViewController
	{
		private float _timer = 0f;
		private Enemy[] _enemies;

		private void Start()
		{
			_enemies = FindObjectsOfType<Enemy>();
		}

		private void Update()
		{
			_timer += Time.deltaTime;
			if (_timer > 1.5f)
			{
				_timer = 0f;
				// 范围内敌人受伤
				foreach (var enemy in _enemies)
				{
					if (enemy == null) continue;
					if (enemy.DistanceToPlayer() < 3f)
					{
						enemy.GetHurt();
					}
				}
			}
		}
	}
}
