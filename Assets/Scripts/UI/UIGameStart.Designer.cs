using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace UI
{
	// Generate Id:d8a6e771-0667-4ec3-a57f-a0cadc99bb29
	public partial class UIGameStart
	{
		public const string Name = "UIGameStart";
		
		[SerializeField]
		public UnityEngine.UI.Button BtnStartGame;
		[SerializeField]
		public RectTransform MoneyUsePanel;
		[SerializeField]
		public UnityEngine.UI.Button Btn_ExpDropRateUp;
		[SerializeField]
		public UnityEngine.UI.Button Btn_MoneyDropRateUp;
		[SerializeField]
		public UnityEngine.UI.Text MoneyRemainText;
		
		private UIGameStartData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			BtnStartGame = null;
			MoneyUsePanel = null;
			Btn_ExpDropRateUp = null;
			Btn_MoneyDropRateUp = null;
			MoneyRemainText = null;
			
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
