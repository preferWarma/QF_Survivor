using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace UI
{
	// Generate Id:11328093-fc66-48b8-b7db-89acae08c1b5
	public partial class UIGameOver
	{
		public const string Name = "UIGameOver";
		
		
		private UIGameOverData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			
			mData = null;
		}
		
		public UIGameOverData Data
		{
			get
			{
				return mData;
			}
		}
		
		UIGameOverData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UIGameOverData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
