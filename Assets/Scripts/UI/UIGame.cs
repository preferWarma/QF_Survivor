using Game;
using Lyf.ObjectPool;
using QFramework;
using UnityEngine;

namespace UI
{
	public class UIGameData : UIPanelData
	{
	}
	public partial class UIGame : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UIGameData ?? new UIGameData();
			// please add init code here
			
			ObjectPool.Instance.ClearAllPool(true);
			
			// 经验注册相关
			Global.Exp.RegisterWithInitValue(exp =>
			{
				if (exp >= Global.ExpNextLevelNeed())
				{
					Global.Exp.Value -= Global.ExpNextLevelNeed();
					Global.Level.Value++;
				}
				ExpValue.fillAmount = (float)exp / Global.ExpNextLevelNeed();	// 填充经验条
			}).UnRegisterWhenGameObjectDestroyed(this);
			
			// 等级注册相关
			Global.Level.RegisterWithInitValue(lv =>
			{
				LvelText.text = $"等级: {lv}";
			}).UnRegisterWhenGameObjectDestroyed(this);

			Global.Level.Register(lv =>
			{
				ExpUpgradePanel.Show();
				Time.timeScale = 0;
				AudioKit.PlaySound("LevelUp");

			}).UnRegisterWhenGameObjectDestroyed(this);
			
			// 游戏持续时间注册相关
			Global.GameLastTime.RegisterWithInitValue(lastTime =>
			{
				// 每30帧更新一次, 避免更新过于频繁
				if (Time.frameCount % 30 != 0) return;
				
				// 获取时分秒
				var h = (int) (lastTime / 3600f);
				var m = (int) ((lastTime - h * 3600f) / 60f);
				var s = (int) (lastTime - h * 3600f - m * 60f);
				TimeText.text = $"游戏时间: {m:D2}:{s:D2}";
			}).UnRegisterWhenGameObjectDestroyed(this);
			
			// 敌人数量注册相关
			Global.EnemyCount.RegisterWithInitValue(cnt =>
			{
				EnemyCountText.text = $"敌人数量: {cnt}";
			}).UnRegisterWhenGameObjectDestroyed(this);
			
			// 游戏通关相关
			var enemyGenerator = FindObjectOfType<EnemyGenerator>();
			Global.EnemyCount.Register(enemyCount =>
			{
				// 当最后一波敌人死亡时, 游戏结束
				if (enemyGenerator.CurrentEnemyWave == null && enemyCount == 0)
				{
					UIKit.OpenPanel<UIGamePass>();
				}
			}).UnRegisterWhenGameObjectDestroyed(this);
			
			// 金币注册相关
			Global.Money.RegisterWithInitValue(money =>
			{
				// 使用富文本
				MoneyText.text = $"金币: <color=yellow>{money}</color>";
			}).UnRegisterWhenGameObjectDestroyed(this);
			
			// Action事件添加
			ActionKit.OnUpdate.Register(() =>
			{
				Global.GameLastTime.Value += Time.deltaTime;
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
