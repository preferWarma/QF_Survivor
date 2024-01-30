using System.Collections.Generic;
using Game;
using Game.Ability;
using QFramework;
using UnityEngine;

/// <summary>
/// 全局配置中心
/// </summary>
public class Global : Architecture<Global>
{
    #region Model层
    
    [Header("死亡后会重置的数据")]
    // 敌人列表
    public static readonly List<Enemy> Enemies = new();
    // 敌人数量, 用于UI显示
    public static readonly BindableProperty<int> EnemyCount = new(0);
    // 经验值
    public static readonly BindableProperty<int> Exp = new(0);
    // 玩家等级
    public static readonly BindableProperty<int> Level = new(1);
    // 游戏持续时间
    public static readonly BindableProperty<float> GameLastTime = new(0f);
    
    [Header("永久保存的数据")]
    // 金币数量
    public static readonly BindableProperty<int> Money = new(0);
    // 经验掉落概率
    public static readonly BindableProperty<float> ExpDropRate = new(0.5f);
    // 金币掉落概率
    public static readonly BindableProperty<float> MoneyDropRate = new(0.2f);
    
    #endregion

    [RuntimeInitializeOnLoadMethod]
    public static void AutoInit()
    {
        ResKit.Init();
        
        // 永久数据的简单存储
        Money.Value = PlayerPrefs.GetInt(nameof(Money), 0);
        Money.Register(money =>
        {
            PlayerPrefs.SetInt(nameof(Money), Money.Value);
        });
        
        ExpDropRate.Value = PlayerPrefs.GetFloat(nameof(ExpDropRate), 0.5f);
        ExpDropRate.Register(rate =>
        {
            PlayerPrefs.SetFloat(nameof(ExpDropRate), ExpDropRate.Value);
        });
        
        MoneyDropRate.Value = PlayerPrefs.GetFloat(nameof(MoneyDropRate), 0.2f);
        MoneyDropRate.Register(rate =>
        {
            PlayerPrefs.SetFloat(nameof(MoneyDropRate), MoneyDropRate.Value);
        });
    }
    
    /// <summary>
    /// 重置非永久保存的数据
    /// </summary>
    public static void ResetAllData()
    {
        // 自身重置
        Enemies.Clear();
        EnemyCount.SetValueWithoutEvent(0);
        Exp.SetValueWithoutEvent(0);
        Level.SetValueWithoutEvent(1);
        GameLastTime.SetValueWithoutEvent(0f);
        
        // 能力重置
        Object.FindObjectOfType<SampleAbility>(true).Reset();
    }

    public static int ExpNextLevelNeed()
    {
        return Level.Value * 5;
    }

    protected override void Init()
    {
        
    }
}