using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace UI
{
	// Generate Id:796b0910-943c-4357-901f-e36761869251
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
		public RectTransform UpgradeBtns;
		[SerializeField]
		public UnityEngine.UI.Button SimpleAbility_Frequency;
		[SerializeField]
		public UnityEngine.UI.Button SimpleAbility_Power;
		
		private UIGameData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			LvelText = null;
			ExpText = null;
			TimeText = null;
			EnemyCountText = null;
			UpgradeBtns = null;
			SimpleAbility_Frequency = null;
			SimpleAbility_Power = null;
			
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
