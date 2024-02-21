using Lyf.ObjectPool;
using UnityEngine;
using QFramework;

namespace Game.PowerUpItem
{
	public partial class AutoCollectController : ViewController
	{
		private Player _player;
		
		private void Start()
		{
			_player = FindObjectOfType<Player>();
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			// Player接触时, 自动收集所有经验和金币
			if (other.CompareTag("Player"))
			{
				AudioKit.PlaySound("AutoCollect");
				
				// 通过tag来找到所有经验值和金币
				foreach (var expObj in GameObject.FindGameObjectsWithTag("ExpObj"))
				{
					// 我们只需要让它们移动到Player的位置即可, Player的CollectableArea组件会自动收集范围内的物品
					expObj.GetComponent<MoneyOrExp>().AutoCollect(true);
				}

				foreach (var moneyObj in GameObject.FindGameObjectsWithTag("MoneyObj"))
				{
					moneyObj.GetComponent<MoneyOrExp>().AutoCollect(true);
				}
				ObjectPool.Instance.Recycle(gameObject); // 使用完后回收本道具
			}
		}
		
	}
}
