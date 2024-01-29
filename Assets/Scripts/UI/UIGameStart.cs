using DG.Tweening;
using QFramework;
using UnityEngine;
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
			
			// 打开/关闭商城按钮注册
			BtnUseMoney.onClick.AddListener(() =>
			{
				DoCloseOrOpen(MoneyUsePanel.gameObject, true);	// 基于DoTween的打开动画
			});
			
			BtnCloseMoneyPanel.onClick.AddListener(() =>
			{
				DoCloseOrOpen(MoneyUsePanel.gameObject, false);	// 基于DoTween的关闭动画
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

		/// <summary>
		/// 使用DoTween实现界面的打开和关闭动画
		/// </summary>
		/// <param name="obj">显示或隐藏的对象</param>
		/// <param name="isOpen">打开(true),关闭(false)</param>
		/// <param name="duration">动画时间</param>
		private void DoCloseOrOpen(GameObject obj, bool isOpen, float duration = 0.3f)
		{
			if (isOpen)
			{
				// 先设置初始状态
				obj.transform.localScale = Vector3.zero;
				
				obj.transform.DOScale(Vector3.one, duration)
					.SetEase(Ease.OutCubic)
					.OnStart(() => obj.SetActive(true));
			}
			else
			{
				obj.transform.DOScale(Vector3.zero, duration)
					.SetEase(Ease.InQuad)
					.OnComplete(() => obj.SetActive(false));
			}
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
