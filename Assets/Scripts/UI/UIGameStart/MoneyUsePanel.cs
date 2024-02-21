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
					AudioKit.PlaySound("AbilityUp");
				});
				itemBtnObj.gameObject.Show();
				
				upgradeItem.SetBtn(itemBtnObj);
			}
			
			// 初始刷新一次
			RefreshUpgradeBtn();
			// 后续每次升级都刷新一次
			CoinUpgradeSystem.OnSystemChanged.Register(RefreshUpgradeBtn).UnRegisterWhenGameObjectDestroyed(this);
			
			// 升级按钮是否可以点击, 金币数量显示
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

		// 刷新升级按钮的显示与隐藏, 实现依赖关系
		private void RefreshUpgradeBtn()
		{
			foreach (var item in this.GetSystem<CoinUpgradeSystem>().CoinUpgradeItems)
			{
				if (item.CanShow())
				{
					item.Btn.gameObject.Show();
				}
				else
				{
					item.Btn.gameObject.Hide();
				}
			}
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