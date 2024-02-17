using Lyf.SaveSystem;
using Lyf.Utils.Singleton;
using QFramework;
using UnityEngine;

/// <summary>
/// 全局游戏逻辑管理
/// </summary>
public class GameController : GlobalSingleton<GameController>
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]   // 在场景加载后自动初始化
    public static void AutoInit()
    {
        _ = Instance;   // 初始化自身
        ResKit.Init();
        _ = Global.Interface;
        
        // 加载永久数据
        SaveManager.Instance.LoadAllRegister(SaveType.PlayerPrefs);
    }
    private void OnApplicationQuit() // 退出游戏时保存永久数据
    {
        Debug.LogWarning("游戏结束");
        SaveManager.Instance.SaveAllRegister(SaveType.PlayerPrefs);
    }
}