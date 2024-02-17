using System.Collections.Generic;
using QFramework;

namespace Systems.CoinUpgrade
{
    public class CoinUpgradeSystem : AbstractSystem
    {
        public List<CoinUpgradeItem> CoinUpgradeItems { get; } = new();
        
        protected override void OnInit()
        {
            CoinUpgradeItems.Add(new CoinUpgradeItem()
                .SetKey("Btn_ExpDropRateUp")
                .SetDescription("($5)经验值掉落率+5%")
                .SetCost(5)
                .SetOnUpgrade(item =>
                {
                    Global.ExpDropRate.Value += 0.05f;
                    Global.Money.Value -= item.Cost;
                    AudioKit.PlaySound("AbilityUp");
                }));
            
            CoinUpgradeItems.Add(new CoinUpgradeItem()
                .SetKey("Btn_MoneyDropRateUp")
                .SetDescription("($5)金币掉落率+5%")
                .SetCost(5)
                .SetOnUpgrade(item =>
                {
                    Global.MoneyDropRate.Value += 0.05f;
                    Global.Money.Value -= item.Cost;
                    AudioKit.PlaySound("AbilityUp");
                }));
            
            CoinUpgradeItems.Add(new CoinUpgradeItem()
                .SetKey("Btn_MaxHpUp")
                .SetDescription("($5)最大生命值+1")
                .SetCost(5)
                .SetOnUpgrade(item =>
                {
                    Global.MaxHp.Value++;
                    Global.Money.Value -= item.Cost;
                    AudioKit.PlaySound("AbilityUp");
                }));
        }
    }
}