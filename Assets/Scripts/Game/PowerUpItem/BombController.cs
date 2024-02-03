using QFramework;
using UnityEngine;

namespace Game.PowerUpItem
{
	public partial class BombController : ViewController
	{
		private void OnTriggerEnter2D(Collider2D other)
		{
			// Player接触到Bomb时，触发爆炸, 并销毁Bomb
			if (other.CompareTag("Player"))
			{
				// 爆炸
				AudioKit.PlaySound("Bomb");
				foreach (var enemy in Global.Enemies)
				{
					enemy.GetHurt(enemy.maxHp, true);
				}
				Destroy(gameObject);	// 使用完后销毁自身
			}
		}
	}
}
