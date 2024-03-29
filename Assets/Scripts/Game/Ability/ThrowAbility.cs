using System;
using Game.EnemyDesign;
using UnityEngine;
using QFramework;
using Object = UnityEngine.Object;

namespace Game.Ability
{
	public partial class ThrowAbility : ViewController
	{
		[Tooltip("冷却时间")] public float coolDown = 1f;
		[Tooltip("伤害")] public int damage = 3;

		private float _timer = 0;
		private Camera _mainCamera;

		private void Start()
		{
			_mainCamera = Camera.main;
		}


		private void Update()
		{
			_timer += Time.deltaTime;
			if (_timer > coolDown)
			{
				Throw();
				_timer = 0;
			}
		}

		private void Throw()
		{
			// 生成投掷物
			ThrowObj.Instantiate()
				.Show()
				.Position(transform.position)
				.Self(rd =>
			{
				// 随机角度抛出
				var randomX = RandomUtility.Choose(-8, -5, 5, 8);
				var randomY = RandomUtility.Choose(5, 8);
				rd.velocity = new Vector2(randomX, randomY);
				
				// 检测碰撞
				rd.OnTriggerEnter2DEvent(col =>
				{
					if (col.CompareTag("Enemy"))
					{
						col.GetComponentInParent<Enemy>().GetHurt(damage);
					}
				}).UnRegisterWhenGameObjectDestroyed(rd);

				// 超出屏幕销毁
				rd.OnUpdate(() =>
				{
					var viewPos = _mainCamera.WorldToViewportPoint(rd.position);
					if (viewPos.x < 0 || viewPos.x > 1 || viewPos.y < 0 || viewPos.y > 1)
					{
						Destroy(rd.gameObject);
					}
				});
			});

		}
	}
}
