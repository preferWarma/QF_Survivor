using System.Collections.Generic;
using Game.Ability;
using QFramework;
using Systems.CoinUpgrade;
using UnityEngine;

namespace Systems.ExpUpgrade
{
    public class ExpUpgradeSystem : AbstractSystem
    {
        public List<ExpUpgradeItem> ExpUpgradeItems { get; } = new();
        
        public static readonly EasyEvent OnSystemChanged = new();
        
        protected override void OnInit()
        {
            AddAttackItem();
            AddFrequencyItem();
            AddRangeItem();
        }

        private void AddAttackItem()
        {
            var lv1 = new ExpUpgradeItem()
                .SetDescription("普攻攻击力+1")
                .SetOnUpgrade(item =>
                {
                    Object.FindObjectOfType<SampleAbility>().Upgrade(1);
                });
            ExpUpgradeItems.Add(lv1);
            
            var lv2 = new ExpUpgradeItem()
                .SetDescription("普攻攻击力+1")
                .SetCondition(item => lv1.CurType == ActionType.Done)
                .SetOnUpgrade(item =>
                {
                    Object.FindObjectOfType<SampleAbility>().Upgrade(1);
                });
            ExpUpgradeItems.Add(lv2);
            
            var lv3 = new ExpUpgradeItem()
                .SetDescription("普攻攻击力+1")
                .SetCondition(item => lv2.CurType == ActionType.Done)
                .SetOnUpgrade(item =>
                {
                    Object.FindObjectOfType<SampleAbility>().Upgrade(1);
                });
            ExpUpgradeItems.Add(lv3);
        }
        
        private void AddFrequencyItem()
        {
            var lv1 = new ExpUpgradeItem()
                .SetDescription("普攻频率+20%")
                .SetOnUpgrade(item =>
                {
                    Object.FindObjectOfType<SampleAbility>().Upgrade(2);
                });
            ExpUpgradeItems.Add(lv1);
            
            var lv2 = new ExpUpgradeItem()
                .SetDescription("普攻频率+20%")
                .SetCondition(item => lv1.CurType == ActionType.Done)
                .SetOnUpgrade(item =>
                {
                    Object.FindObjectOfType<SampleAbility>().Upgrade(2);
                });
            ExpUpgradeItems.Add(lv2);
            
            var lv3 = new ExpUpgradeItem()
                .SetDescription("普攻频率+%20")
                .SetCondition(item => lv2.CurType == ActionType.Done)
                .SetOnUpgrade(item =>
                {
                    Object.FindObjectOfType<SampleAbility>().Upgrade(2);
                });
            ExpUpgradeItems.Add(lv3);
        }
        
        private void AddRangeItem()
        {
            var lv1 = new ExpUpgradeItem()
                .SetDescription("普攻范围+1")
                .SetOnUpgrade(item =>
                {
                    Object.FindObjectOfType<SampleAbility>().Upgrade(3);
                });
            ExpUpgradeItems.Add(lv1);
            
            var lv2 = new ExpUpgradeItem()
                .SetDescription("普攻范围+1")
                .SetCondition(item => lv1.CurType == ActionType.Done)
                .SetOnUpgrade(item =>
                {
                    Object.FindObjectOfType<SampleAbility>().Upgrade(3);
                });
            ExpUpgradeItems.Add(lv2);
            
            var lv3 = new ExpUpgradeItem()
                .SetDescription("普攻范围+1")
                .SetCondition(item => lv2.CurType == ActionType.Done)
                .SetOnUpgrade(item =>
                {
                    Object.FindObjectOfType<SampleAbility>().Upgrade(3);
                });
            ExpUpgradeItems.Add(lv3);
            
        }
        
    }
}