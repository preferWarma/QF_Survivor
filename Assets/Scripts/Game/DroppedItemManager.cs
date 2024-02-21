using Lyf.ObjectPool;
using QFramework;
using UnityEngine;

namespace Game
{
	public partial class DroppedItemManager : ViewController, ISingleton
	{
		public static DroppedItemManager Instance => MonoSingletonProperty<DroppedItemManager>.Instance;
		
		// TODO: 后续可能会考虑加入到全局配置中
		[Header("恢复类物品掉落概率")]
		public float hpItemDropRate = 0.2f;
		public float bombItemDropRate = 0.2f;
		public float autoCollectItemDropRate = 0.2f;
		
		// TODO: 后续考虑由Enemy传入一个掉落列表的参数，并设置对应的概率
		public void GenerateItem(Vector3 position)
		{
			if (Random.Range(0, 1f) < Global.ExpDropRate.Value)
			{
				GenerateObj(ExpObj.gameObject, position);
			}
			
			if (Random.Range(0, 1f) < Global.MoneyDropRate.Value)
			{
				GenerateObj(MoneyObj.gameObject, position);
			}
			
			if (Random.Range(0, 1f) < hpItemDropRate)
			{
				GenerateObj(RecoverHpObj.gameObject, position);
			}
			
			if (Random.Range(0, 1f) < bombItemDropRate)
			{
				GenerateObj(BombObj.gameObject, position);
			}
			
			if (Random.Range(0, 1f) < autoCollectItemDropRate)
			{
				GenerateObj(AutoCollectObj.gameObject, position);
			}
			
		}
		
		private void GenerateObj(GameObject prefab, Vector3 position)
		{
			// 在position附近的小圆内随机生成一个位置, 避免物品重叠过于严重
			position += Random.insideUnitSphere * 0.7f;
			
			// 使用对象池, 减小性能开销
			ObjectPool.Instance.Allocate(prefab, obj =>
			{
				obj.Position(position)
					.Show();
			});
		}

		public void OnSingletonInit()
		{
			
		}
	}
}
