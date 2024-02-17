using System.Linq;
using UnityEngine;
using QFramework;

namespace Game.Ability
{
	public partial class SampleAbility : ViewController
	{
		[Tooltip("攻击范围")] public float attackRange = 3f;
		[Tooltip("攻击力")] public int attackDamage = 1;
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
		/// 升级SampleAbility, type = 1表示升级攻击力和攻击范围, type = 2:表示升级攻击频率
		/// </summary>
		public void Upgrade(int type = 1)
		{
			switch (type)
			{
				case 1:
					attackRange += 1f;
					attackDamage += 1;
					break;
				case 2:
					attackFrequency *= 0.8f;
					break;
			}
			AudioKit.PlaySound("AbilityUp");
		}

		public void Reset()
		{
			attackRange = 3.5f;
			attackDamage = 1;
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(transform.position, attackRange);
		}
		
	}
}
