using QFramework;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
	public class UIGameOverData : UIPanelData
	{
	}
	public partial class UIGameOver : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UIGameOverData ?? new UIGameOverData();
			// please add init code here
			ActionKit.OnUpdate.Register(() =>
			{
				if (Input.GetKeyDown(KeyCode.Space))
				{
					CloseSelf();
					SceneManager.LoadScene("SampleScene");
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
