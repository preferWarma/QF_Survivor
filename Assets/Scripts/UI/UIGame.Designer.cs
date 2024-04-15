using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace UI
{
	// Generate Id:9588d238-8568-4a73-9143-4ecf07dc2fb4
	public partial class UIGame
	{
		public const string Name = "UIGame";
		
		[SerializeField]
		public UnityEngine.UI.Text LvelText;
		[SerializeField]
		public UnityEngine.UI.Text TimeText;
		[SerializeField]
		public UnityEngine.UI.Text EnemyCountText;
		[SerializeField]
		public UnityEngine.UI.Text MoneyText;
		[SerializeField]
		public ExpUpgradePanel ExpUpgradePanel;
		[SerializeField]
		public UnityEngine.UI.Image ExpValue;
		
		private UIGameData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			LvelText = null;
			TimeText = null;
			EnemyCountText = null;
			MoneyText = null;
			ExpUpgradePanel = null;
			ExpValue = null;
			
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
