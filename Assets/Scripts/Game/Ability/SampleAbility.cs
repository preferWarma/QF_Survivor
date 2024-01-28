using UnityEngine;
using QFramework;

namespace Game.Ability
{
	public partial class SampleAbility : ViewController
	{
		[Tooltip("攻击范围")] public float attackRange = 3f;
		[Tooltip("攻击力")] public int attackDamage = 1;
		
		private float _timer = 0f;
		
		private void Update()
		{
			_timer += Time.deltaTime;
			if (_timer > 1.5f)
			{
				_timer = 0f;
				// 范围内敌人受伤
				foreach (var enemy in Global.Enemies)
				{
					if (enemy == null) continue;
					if (enemy.DistanceToPlayer() < attackRange)
					{
						enemy.GetHurt(attackDamage);
					}
				}
			}
		}
		
		public void Upgrade()
		{
			attackRange += 1f;
			attackDamage += 1;
		}

		public void Reset()
		{
			attackRange = 3f;
			attackDamage = 1;
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(transform.position, attackRange);
		}
		
	}
}
