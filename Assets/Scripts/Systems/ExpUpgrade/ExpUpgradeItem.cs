using System;
using Systems.CoinUpgrade;
using UnityEngine.UI;

namespace Systems.ExpUpgrade
{
    public class ExpUpgradeItem
    {
        public string Description { get; private set; }
        public Button Btn { get; private set; }
        public ActionType CurType { get; private set; } = ActionType.Doing;
        
        private Action<ExpUpgradeItem> _onUpgrade;
        private Func<ExpUpgradeItem, bool> _condition;

        /// 依赖条件检查, 比如lv2的升级需要lv1的升级完成后才能进行
        public bool CanShow()
        {
            return CurType == ActionType.Doing && (_condition == null || _condition(this));
        }
        
        public void Upgrade()
        {
            _onUpgrade?.Invoke(this);
            CurType = ActionType.Done;
            ExpUpgradeSystem.OnSystemChanged.Trigger();
        }

        #region 链式调用
        
        public ExpUpgradeItem SetDescription(string description)
        {
            Description = description;
            return this;
        }
        
        public ExpUpgradeItem SetBtn(Button btn)
        {
            Btn = btn;
            return this;
        }
        
        public ExpUpgradeItem SetOnUpgrade(Action<ExpUpgradeItem> onUpgrade)
        {
            _onUpgrade = onUpgrade;
            return this;
        }
        
        public ExpUpgradeItem SetCondition(Func<ExpUpgradeItem, bool> condition)
        {
            _condition = condition;
            return this;
        }
        
        public ExpUpgradeItem SetType(ActionType type)
        {
            CurType = type;
            return this;
        }

        #endregion
    }
}