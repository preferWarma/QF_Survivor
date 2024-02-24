using System.Linq;
using UnityEngine;
using QFramework;

namespace Game.Ability
{
	public partial class SampleAbility : ViewController
	{
		[Tooltip("攻击范围")] public float attackRange = 3.5f;
		[Tooltip("攻击力")] public float attackDamage = 1f;
		[Tooltip("攻击频率")] public float attackFrequency = 1.5f;
		
		private float _timer;
		
		private void Update()
		{
			_timer += Time.deltaTime;
			if (_timer > attackFrequency)
			{
				_timer = 0f;
				// 范围内敌人受伤
				var enemies = Global.Enemies.Where(enemy => enemy != null && enemy.DistanceToPlayer() < attackRange);
				foreach (var enemy in enemies)
				{
					enemy.GetHurt(attackDamage);
				}
			}
		}
		
		/// <summary>
		/// 升级SampleAbility, type = 1表示升级攻击力, type = 2:表示升级攻击频率, type = 3:表示升级攻击范围
		/// </summary>
		public void Upgrade(int type, float addValue = 0.5f)
		{
			switch (type)
			{
				case 1:
					attackDamage += addValue;
					break;
				case 2:
					attackFrequency *= 0.8f;
					break;
				case 3:
					attackRange += addValue;
					break;
			}
		}

		public void Reset()
		{
			attackRange = 3.5f;
			attackDamage = 1;
			attackFrequency = 1.5f;
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(transform.position, attackRange);
		}
		
	}
}
