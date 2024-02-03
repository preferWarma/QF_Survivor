using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace UI
{
	// Generate Id:1fc19431-c006-4de8-84eb-91fa3fc57476
	public partial class UIGameStart
	{
		public const string Name = "UIGameStart";
		
		[SerializeField]
		public UnityEngine.UI.Button BtnStartGame;
		[SerializeField]
		public UnityEngine.UI.Button BtnUseMoney;
		[SerializeField]
		public RectTransform MoneyUsePanel;
		[SerializeField]
		public UnityEngine.UI.Text MoneyRemainText;
		[SerializeField]
		public UnityEngine.UI.Button BtnCloseMoneyPanel;
		[SerializeField]
		public UnityEngine.UI.Button Btn_ExpDropRateUp;
		[SerializeField]
		public UnityEngine.UI.Button Btn_MoneyDropRateUp;
		[SerializeField]
		public UnityEngine.UI.Button Btn_MaxHpUp;
		
		private UIGameStartData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			BtnStartGame = null;
			BtnUseMoney = null;
			MoneyUsePanel = null;
			MoneyRemainText = null;
			BtnCloseMoneyPanel = null;
			Btn_ExpDropRateUp = null;
			Btn_MoneyDropRateUp = null;
			Btn_MaxHpUp = null;
			
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
