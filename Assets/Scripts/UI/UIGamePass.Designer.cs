using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace UI
{
	// Generate Id:0c0d335a-32a7-43d5-8c4a-410157ef34b6
	public partial class UIGamePass
	{
		public const string Name = "UIGamePass";
		
		
		private UIGamePassData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			
			mData = null;
		}
		
		public UIGamePassData Data
		{
			get
			{
				return mData;
			}
		}
		
		UIGamePassData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UIGamePassData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
