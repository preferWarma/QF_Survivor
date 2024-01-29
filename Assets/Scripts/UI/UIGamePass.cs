using UnityEngine;
using QFramework;
using UnityEngine.SceneManagement;

namespace UI
{
	public class UIGamePassData : UIPanelData
	{
	}
	public partial class UIGamePass : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UIGamePassData ?? new UIGamePassData();
			// please add init code here
			
			// Action事件注册
			ActionKit.OnUpdate.Register(() =>
			{
				if (Input.GetKeyDown(KeyCode.Space))
				{
					CloseSelf();
					SceneManager.LoadScene("GameStart");
				}
			}).UnRegisterWhenGameObjectDestroyed(this);
		}
		
		protected override void OnOpen(IUIData uiData = null)
		{
			Time.timeScale = 0f;
		}
		
		protected override void OnShow()
		{
		}
		
		protected override void OnHide()
		{
		}
		
		protected override void OnClose()
		{
			Time.timeScale = 1f;
			Global.ResetAllData();
		}
	}
}
