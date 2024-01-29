using QFramework;
using UnityEngine;

namespace Game
{
	public partial class DroppedItemManager : ViewController, ISingleton
	{
		public static DroppedItemManager Instance => MonoSingletonProperty<DroppedItemManager>.Instance;
		
		
		// TODO: 后续考虑由Enemy传入一个掉落列表的参数，并设置对应的概率
		public void GenerateItem(Vector3 position)
		{
			if (Random.Range(0, 1f) < Global.ExpDropRate.Value)
			{
				GenerateExpObj(position);
			}
			if (Random.Range(0, 1f) < Global.MoneyDropRate.Value)
			{
				GenerateMoneyObj(position);
			}
		}
		
		private void GenerateExpObj(Vector3 position)
		{
			ExpObj.Instantiate()
				.Position(position)
				.Show();
		}
		
		private void GenerateMoneyObj(Vector3 position)
		{
			MoneyObj.Instantiate()
				.Position(position)
				.Show();
		}
		

		public void OnSingletonInit()
		{
			
		}
	}
}
