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
        
        private Action<CoinUpgradeItem> _onUpgrade;
        
        public void Upgrade()
        {
            _onUpgrade?.Invoke(this);
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

        #endregion
    }
}