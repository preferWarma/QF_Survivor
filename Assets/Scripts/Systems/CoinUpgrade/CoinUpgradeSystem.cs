using System.Collections.Generic;
using Lyf.SaveSystem;
using QFramework;
using UnityEngine;

namespace Systems.CoinUpgrade
{
    public class CoinUpgradeSystem : AbstractSystem, ISaveWithPlayerPrefs
    {
        public List<CoinUpgradeItem> CoinUpgradeItems { get; } = new();
        
        public static readonly EasyEvent OnSystemChanged = new();
        
        protected override void OnInit()
        {
            AddExpItem();
            AddMoneyItem();
            AddHpItem();
            
            // SaveManager.Load(this, SaveType.PlayerPrefs);
            // OnSystemChanged.Register(() => SaveManager.Save(this, SaveType.PlayerPrefs));
            // 改为统一注册的方式来加载和存储
            SaveManager.Instance.Register(this, SaveType.PlayerPrefs);
        }
        
        private void AddExpItem()
        {
            var lv1 = new CoinUpgradeItem()
                .SetKey("Btn_ExpDropRateUp1")
                .SetDescription("($5)经验值掉落率+2%")
                .SetCost(5)
                .SetOnUpgrade(item =>
                {
                    Global.ExpDropRate.Value += 0.02f;
                    Global.Money.Value -= item.Cost;
                    AudioKit.PlaySound("AbilityUp");
                });
            CoinUpgradeItems.Add(lv1);
            
            var lv2 = new CoinUpgradeItem()
                .SetKey("Btn_ExpDropRateUp2")
                .SetDescription("($10)经验值掉落率+3%")
                .SetCost(10)
                .SetCondition(item => lv1.CurType == ActionType.Done)
                .SetOnUpgrade(item =>
                {
                    Global.ExpDropRate.Value += 0.03f;
                    Global.Money.Value -= item.Cost;
                    AudioKit.PlaySound("AbilityUp");
                });
            CoinUpgradeItems.Add(lv2);
            
            var lv3 = new CoinUpgradeItem()
                .SetKey("Btn_ExpDropRateUp3")
                .SetDescription("($20)经验值掉落率+5%")
                .SetCost(20)
                .SetCondition(item => lv2.CurType == ActionType.Done)
                .SetOnUpgrade(item =>
                {
                    Global.ExpDropRate.Value += 0.05f;
                    Global.Money.Value -= item.Cost;
                    AudioKit.PlaySound("AbilityUp");
                });
            CoinUpgradeItems.Add(lv3);
            
            var lv4 = new CoinUpgradeItem()
                .SetKey("Btn_ExpDropRateUp4")
                .SetDescription("($50)经验值掉落率+10%")
                .SetCost(50)
                .SetCondition(item => lv3.CurType == ActionType.Done)
                .SetOnUpgrade(item =>
                {
                    Global.ExpDropRate.Value += 0.1f;
                    Global.Money.Value -= item.Cost;
                    AudioKit.PlaySound("AbilityUp");
                });
            CoinUpgradeItems.Add(lv4);
        }
        
        private void AddMoneyItem()
        {
            CoinUpgradeItems.Add(new CoinUpgradeItem()
                .SetKey("Btn_MoneyDropRateUp")
                .SetDescription("($5)金币掉落率+2%")
                .SetCost(5)
                .SetOnUpgrade(item =>
                {
                    Global.MoneyDropRate.Value += 0.02f;
                    Global.Money.Value -= item.Cost;
                    AudioKit.PlaySound("AbilityUp");
                }));
        }
        
        private void AddHpItem()
        {
            CoinUpgradeItems.Add(new CoinUpgradeItem()
                .SetKey("Btn_MaxHpUp")
                .SetDescription("($30)最大生命值+1")
                .SetCost(30)
                .SetOnUpgrade(item =>
                {
                    Global.MaxHp.Value++;
                    Global.Money.Value -= item.Cost;
                    AudioKit.PlaySound("AbilityUp");
                }));
        }

        #region 存储相关
        public string SAVE_KEY => "CoinUpgradeSystem";

        public void SaveWithPlayerPrefs()
        {
            foreach (var item in CoinUpgradeItems)
            {
                PlayerPrefs.SetInt(item.Key, item.CurType == ActionType.Done ? 1 : 0);
            }
        }

        public void LoadWithPlayerPrefs()
        {
            foreach (var item in CoinUpgradeItems)
            {
                var value = PlayerPrefs.GetInt(item.Key, 0);
                item.SetType(value == 1 ? ActionType.Done : ActionType.Doing);
            }
        }
        #endregion
    }
}