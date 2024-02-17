using System;
using UnityEngine.UI;

namespace Systems.CoinUpgrade
{
    public class CoinUpgradeItem
    {
        public string Key { get; private set; }
        public string Description { get; private set; }
        public int Cost { get; private set; }
        public Button Btn { get; private set; }
        public ActionType CurType { get; private set; } = ActionType.Doing;
        
        private Action<CoinUpgradeItem> _onUpgrade;
        private Func<CoinUpgradeItem, bool> _condition;

        /// 依赖条件检查, 比如lv2的升级需要lv1的升级完成后才能进行
        public bool CanShow()
        {
            return CurType == ActionType.Doing && (_condition == null || _condition(this));
        }
        
        public void Upgrade()
        {
            _onUpgrade?.Invoke(this);
            CurType = ActionType.Done;
            CoinUpgradeSystem.OnSystemChanged.Trigger();
        }

        #region 链式调用

        public CoinUpgradeItem SetKey(string key)
        {
            Key = key;
            return this;
        }
        
        public CoinUpgradeItem SetDescription(string description)
        {
            Description = description;
            return this;
        }
        
        public CoinUpgradeItem SetCost(int cost)
        {
            Cost = cost;
            return this;
        }
        
        public CoinUpgradeItem SetBtn(Button btn)
        {
            Btn = btn;
            return this;
        }
        
        public CoinUpgradeItem SetOnUpgrade(Action<CoinUpgradeItem> onUpgrade)
        {
            _onUpgrade = onUpgrade;
            return this;
        }
        
        public CoinUpgradeItem SetCondition(Func<CoinUpgradeItem, bool> condition)
        {
            _condition = condition;
            return this;
        }
        
        public CoinUpgradeItem SetType(ActionType type)
        {
            CurType = type;
            return this;
        }

        #endregion
    }
    
    public enum ActionType
    {
        // 正在进行
        Doing,
        // 已经完成
        Done
    }
}