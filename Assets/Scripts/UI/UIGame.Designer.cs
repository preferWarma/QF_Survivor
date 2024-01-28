using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace UI
{
	// Generate Id:027aa033-362e-4f09-a41f-2c7f5d884827
	public partial class UIGame
	{
		public const string Name = "UIGame";
		
		[SerializeField]
		public UnityEngine.UI.Text LvelText;
		[SerializeField]
		public UnityEngine.UI.Text ExpText;
		[SerializeField]
		public UnityEngine.UI.Text TimeText;
		[SerializeField]
		public UnityEngine.UI.Text EnemyCountText;
		[SerializeField]
		public UnityEngine.UI.Button UpgradeBtn_SimpleAbility;
		
		private UIGameData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			LvelText = null;
			ExpText = null;
			TimeText = null;
			EnemyCountText = null;
			UpgradeBtn_SimpleAbility = null;
			
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
