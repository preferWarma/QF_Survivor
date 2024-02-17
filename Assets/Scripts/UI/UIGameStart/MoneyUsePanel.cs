/****************************************************************************
 * 2024.2 LIFELINE-R9000P
 ****************************************************************************/

using QFramework;
using Systems.CoinUpgrade;
using UnityEngine.UI;

namespace UI
{
	public partial class MoneyUsePanel : UIElement, IController
	{
		private void Start()
		{
			// 升级按钮的绑定
			foreach (var upgradeItem in this.GetSystem<CoinUpgradeSystem>().CoinUpgradeItems)
			{
				var itemBtnObj =  Btn_UpgradeTemplate.InstantiateWithParent(Btn_UpgradeRoot);
				itemBtnObj.GetComponentInChildren<Text>().text = upgradeItem.Description;
				itemBtnObj.onClick.AddListener(() =>
				{
					upgradeItem.Upgrade();
				});
				itemBtnObj.gameObject.Show();
				
				upgradeItem.SetBtn(itemBtnObj);
			}
			
			// 升级按钮的显示与隐藏, 金币数量显示
			Global.Money.RegisterWithInitValue(money =>
			{
				MoneyRemainText.text = $"剩余金币: {money}";
				
				foreach (var item in this.GetSystem<CoinUpgradeSystem>().CoinUpgradeItems)
				{
					if (money < item.Cost)
					{
						item.Btn.interactable = false;
						item.Btn.GetComponentInChildren<Text>().text = item.Description + " (金币不足)";
					}
					else
					{
						item.Btn.interactable = true;
						item.Btn.GetComponentInChildren<Text>().text = item.Description;
					}
				}
			}).UnRegisterWhenGameObjectDestroyed(this);
			
			// 关闭按钮注册
			BtnCloseMoneyPanel.onClick.AddListener(() =>
			{
				UIAnimationController.DoClose(gameObject);
			});
		}

		protected override void OnBeforeDestroy()
		{
		}

		public IArchitecture GetArchitecture()
		{
			return Global.Interface;
		}
	}
}