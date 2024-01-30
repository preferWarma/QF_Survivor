using QFramework;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// 用于收集物品的区域
    /// </summary>
    public class CollectableArea : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            var otherTag = other.tag;

            switch (otherTag)
            {
                case "ExpObj":
                    Global.Exp.Value++;
                    AudioKit.PlaySound("GetExp");
                    Destroy(other.gameObject);
                    break;
                
                case "MoneyObj":
                    Global.Money.Value++;
                    AudioKit.PlaySound("GetCoin");
                    Destroy(other.gameObject);
                    break;
                
                case "RecoverObj":
                    Global.Hp.Value = Mathf.Min(Player.MaxHp, Global.Hp.Value + 1);
                    AudioKit.PlaySound("RecoverHp");
                    Destroy(other.gameObject);
                    break;
            }
        }
    }
}
