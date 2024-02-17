using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace UI
{
	// Generate Id:9e1ac30a-f671-4e28-ad6b-796bd33b18a4
	public partial class UIGameStart
	{
		public const string Name = "UIGameStart";
		
		[SerializeField]
		public UnityEngine.UI.Button BtnStartGame;
		[SerializeField]
		public UnityEngine.UI.Button BtnUseMoney;
		[SerializeField]
		public MoneyUsePanel MoneyUsePanel;
		
		private UIGameStartData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			BtnStartGame = null;
			BtnUseMoney = null;
			MoneyUsePanel = null;
			
			mData = null;
		}
		
		public UIGameStartData Data
		{
			get
			{
				return mData;
			}
		}
		
		UIGameStartData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UIGameStartData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
