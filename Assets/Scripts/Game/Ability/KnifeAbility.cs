using System.Linq;
using Game.EnemyDesign;
using QFramework;
using UnityEngine;

namespace Game.Ability
{
	public partial class KnifeAbility : ViewController
	{
		[Tooltip("冷却时间")] public float coolDownTime = 1.0f;
		[Tooltip("伤害值")] public float damage = 2.5f;
		[Tooltip("飞行速度")] public float speed = 15f;
		
		private float _timer = 0f;
		private Player _player;
		private Camera _mainCamera;

		private void Start()
		{
			_player = FindObjectOfType<Player>();
			_mainCamera = Camera.main;
		}

		private void Update()
		{
			_timer += Time.deltaTime;
			if (_timer > coolDownTime)
			{
				_timer = 0f;
				ThrowKnife();
			}
		}

		private void ThrowKnife()
		{
			// 找最近的敌人
			var target = Global.Enemies
				.Where(enemy => enemy != null)
				.OrderBy(enemy => enemy.DistanceToPlayer())
				.FirstOrDefault();
			if (target == null) return;
			// 生成飞刀
			KnifeObj.Instantiate()
				.Position(transform.position)
				.Show()
				.Self(self =>
				{
					// 飞向敌人
					var dir = (target.transform.position - _player.transform.position).normalized;
					self.velocity = dir * speed;
					
					// 检测碰撞
					self.OnTriggerEnter2DEvent(col =>
					{
						if (col.CompareTag("Enemy"))
						{
							col.GetComponentInParent<Enemy>().GetHurt(damage);
							Destroy(self.gameObject);
						}
					}).UnRegisterWhenGameObjectDestroyed(self.gameObject);
					
					// 超出屏幕销毁
					self.OnUpdate(() =>
					{
						var viewPos = _mainCamera.WorldToViewportPoint(self.position);
						if (viewPos.x < 0 || viewPos.x > 1 || viewPos.y < 0 || viewPos.y > 1)
						{
							Destroy(self.gameObject);
						}
					});
				});
		}
	}
}
