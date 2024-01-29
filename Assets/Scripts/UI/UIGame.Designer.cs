using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace UI
{
	// Generate Id:d3b92404-b144-4dda-9515-ee009da0cdee
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
		public UnityEngine.UI.Text MoneyText;
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
			MoneyText = null;
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
