using System.Collections.Generic;
using Game;
using Game.Ability;
using Game.EnemyDesign;
using Lyf.SaveSystem;
using QFramework;
using Systems.CoinUpgrade;
using Systems.ExpUpgrade;
using UnityEditor;
using UnityEngine;
using SaveType = Lyf.SaveSystem.SaveType;

/// <summary>
/// 全局配置中心
/// </summary>
public class Global : Architecture<Global>, ISaveWithPlayerPrefs
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
    // 玩家生命值
    public static readonly BindableProperty<int> Hp = new();
    // 游戏持续时间
    public static readonly BindableProperty<float> GameLastTime = new(0f);
    
    [Header("永久保存的数据")]
    // 金币数量
    public static readonly BindableProperty<int> Money = new(0);
    // 经验掉落概率
    public static readonly BindableProperty<float> ExpDropRate = new(0.5f);
    // 金币掉落概率
    public static readonly BindableProperty<float> MoneyDropRate = new(0.2f);
    // 玩家最大血量上限
    public static readonly BindableProperty<int> MaxHp = new(3);
    
    #endregion
    
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
        Hp.SetValueWithoutEvent(MaxHp.Value);
        GameLastTime.SetValueWithoutEvent(0f);
        
        // 能力重置
        Object.FindObjectOfType<SampleAbility>(true).Reset();
        Interface.GetSystem<ExpUpgradeSystem>().Reset();
    }

    public static int ExpNextLevelNeed()
    {
        return Level.Value * 5;
    }

    protected override void Init()
    {
        RegisterSystem(new CoinUpgradeSystem());
        RegisterSystem(new ExpUpgradeSystem());
        
        // 注册存储系统
        SaveManager.Instance.Register(this, SaveType.PlayerPrefs);
    }
    
    // 清除永久数据
    [MenuItem("Lyf/Reset PlayerPrefs")]
    public static void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

    #region 存储相关
    public string SAVE_KEY => "Global";
    public void SaveWithPlayerPrefs()
    {
        var data = new GlobalSaveData()
        {
            Money = Money.Value,
            ExpDropRate = ExpDropRate.Value,
            MoneyDropRate = MoneyDropRate.Value,
            MaxHp = MaxHp.Value
        };
        SaveManager.SaveWithPlayerPrefs(SAVE_KEY, data);
    }

    public void LoadWithPlayerPrefs()
    {
        var data = SaveManager.LoadWithPlayerPrefs<GlobalSaveData>(SAVE_KEY);
        if (data == null) return;
        Money.SetValueWithoutEvent(data.Money);
        ExpDropRate.SetValueWithoutEvent(data.ExpDropRate);
        MoneyDropRate.SetValueWithoutEvent(data.MoneyDropRate);
        MaxHp.SetValueWithoutEvent(data.MaxHp);
    }
    #endregion
}

// 需要存储的永久数据集
public class GlobalSaveData
{
    public int Money;
    public float ExpDropRate;
    public float MoneyDropRate;
    public int MaxHp;
}