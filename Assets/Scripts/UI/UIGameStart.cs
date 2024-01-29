using QFramework;
using UnityEngine.SceneManagement;

namespace UI
{
	public class UIGameStartData : UIPanelData
	{
	}
	public partial class UIGameStart : UIPanel
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
			
			// 升级按钮注册
			Btn_ExpDropRateUp.onClick.AddListener(() =>
			{
				Global.ExpDropRate.Value += 0.05f;
				Global.Money.Value -= 5;
			});
			
			Btn_MoneyDropRateUp.onClick.AddListener(() =>
			{
				Global.MoneyDropRate.Value += 0.05f;
				Global.Money.Value -= 5;
			});
			
			// 升级按钮的显示与隐藏, 金币数量显示
			Global.Money.RegisterWithInitValue(money =>
			{
				MoneyRemainText.text = $"剩余金币: {money}";
				if (money >= 5)
				{
					Btn_ExpDropRateUp.Show();
					Btn_MoneyDropRateUp.Show();
				}
				else
				{
					Btn_ExpDropRateUp.Hide();
					Btn_MoneyDropRateUp.Hide();
				}
			}).UnRegisterWhenGameObjectDestroyed(this);
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
	}
}
