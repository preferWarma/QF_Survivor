using QFramework;
using UnityEngine.SceneManagement;

namespace UI
{
	public class UIGameStartData : UIPanelData
	{
	}
	public partial class UIGameStart : UIPanel, IController
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UIGameStartData ?? new UIGameStartData();
			// please add init code here
			
			// 开始游戏按钮注册
			BtnStartGame.onClick.AddListener(() =>
			{
				CloseSelf();
				SceneManager.LoadScene("Game");
			});
			
			// 打开/关闭商城按钮注册
			BtnUseMoney.onClick.AddListener(() =>
			{
				UIAnimationController.DoOpen(MoneyUsePanel.gameObject);
			});
		}
		
		protected override void OnOpen(IUIData uiData = null)
		{
		}
		
		protected override void OnShow()
		{
		}
		
		protected override void OnHide()
		{
		}
		
		protected override void OnClose()
		{
		}

		public IArchitecture GetArchitecture()
		{
			return Global.Interface;
		}
	}
}
