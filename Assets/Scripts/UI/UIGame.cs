using Game;
using Game.Ability;
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
			
			// 经验注册相关
			Global.Exp.RegisterWithInitValue(exp =>
			{
				ExpText.text = $"经验值: {exp}";
				if (exp >= 5)
				{
					Global.Level.Value++;
					Global.Exp.Value -= 5;
				}
			}).UnRegisterWhenGameObjectDestroyed(this);
			
			// 等级注册相关
			Global.Level.RegisterWithInitValue(lv =>
			{
				LvelText.text = $"等级: {lv}";
			}).UnRegisterWhenGameObjectDestroyed(this);

			Global.Level.Register(lv =>
			{
				Time.timeScale = 0f;
				UpgradeBtn_SimpleAbility.Show();

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
			
			var enemyGenerator = FindObjectOfType<EnemyGenerator>();
			Global.GameLastTime.Register(lastTime =>
			{
				// 当最后一波敌人死亡时, 游戏结束
				if (enemyGenerator.CurrentEnemyWave == null && Global.Enemies.Count == 0)
				{
					UIKit.OpenPanel<UIGamePass>();
				}
			}).UnRegisterWhenGameObjectDestroyed(this);
			
			// 升级按钮绑定监听
			UpgradeBtn_SimpleAbility.onClick.AddListener(() =>
			{
				FindObjectOfType<SampleAbility>().Upgrade();
				Time.timeScale = 1f;
				UpgradeBtn_SimpleAbility.Hide();
			});
			
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
