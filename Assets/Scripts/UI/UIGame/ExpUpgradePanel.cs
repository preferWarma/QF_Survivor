/****************************************************************************
 * 2024.2 LIFELINE-R9000P
 ****************************************************************************/

using UnityEngine.UI;
using QFramework;
using Systems.ExpUpgrade;
using UnityEngine;

namespace UI
{
	public partial class ExpUpgradePanel : UIElement, IController
	{
		private void Start()
		{
			// 升级按钮的绑定
			foreach (var upgradeItem in this.GetSystem<ExpUpgradeSystem>().ExpUpgradeItems)
			{
				var itemBtnObj =  ExpUpgradeItem_Template.InstantiateWithParent(BtnRoot);
				itemBtnObj.GetComponentInChildren<Text>().text = upgradeItem.Description;
				itemBtnObj.onClick.AddListener(() =>
				{
					upgradeItem.Upgrade();
					Time.timeScale = 1f;
					AudioKit.PlaySound("AbilityUp");
					gameObject.Hide();
				});
				itemBtnObj.gameObject.Show();
				
				upgradeItem.SetBtn(itemBtnObj);
			}
			
			// 初始刷新一次
			RefreshUpgradeBtn();
			// 后续每次升级都刷新一次
			ExpUpgradeSystem.OnSystemChanged.Register(RefreshUpgradeBtn).UnRegisterWhenGameObjectDestroyed(this);
		}

		// 刷新升级按钮的显示与隐藏, 实现依赖关系
		public void RefreshUpgradeBtn()
		{
			foreach (var item in this.GetSystem<ExpUpgradeSystem>().ExpUpgradeItems)
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