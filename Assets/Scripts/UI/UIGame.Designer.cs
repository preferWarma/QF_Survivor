using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace UI
{
	// Generate Id:6d278b2c-b8ee-4ae0-a7f0-df29fd6eff9f
	public partial class UIGame
	{
		public const string Name = "UIGame";
		
		[SerializeField]
		public UnityEngine.UI.Text HpText;
		[SerializeField]
		public UnityEngine.UI.Text LvelText;
		[SerializeField]
		public UnityEngine.UI.Text ExpText;
		[SerializeField]
		public UnityEngine.UI.Text TimeText;
		[SerializeField]
		public UnityEngine.UI.Text EnemyCountText;
		[SerializeField]
		public UnityEngine.UI.Text MoneyText;
		[SerializeField]
		public ExpUpgradePanel ExpUpgradePanel;
		
		private UIGameData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			HpText = null;
			LvelText = null;
			ExpText = null;
			TimeText = null;
			EnemyCountText = null;
			MoneyText = null;
			ExpUpgradePanel = null;
			
			mData = null;
		}
		
		public UIGameData Data
		{
			get
			{
				return mData;
			}
		}
		
		UIGameData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UIGameData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
