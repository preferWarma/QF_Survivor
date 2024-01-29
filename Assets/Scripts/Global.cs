using System.Collections.Generic;
using Game;
using Game.Ability;
using QFramework;
using UnityEngine;

/// <summary>
/// 全局配置中心
/// </summary>
public static class Global
{
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
        Object.FindObjectOfType<SampleAbility>().Reset();
    }

    public static int ExpNextLevelNeed()
    {
        return Level.Value * 5;
    }
    
}