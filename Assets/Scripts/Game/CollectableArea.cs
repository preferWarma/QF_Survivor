using QFramework;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// 用于收集经验值的区域
    /// </summary>
    public class CollectableArea : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("ExpObj"))
            {
                Global.Exp.Value++;
                AudioKit.PlaySound("GetExp");
                Destroy(other.gameObject);
            }
            if (other.CompareTag("MoneyObj"))
            {
                Global.Money.Value++;
                AudioKit.PlaySound("GetCoin");
                Destroy(other.gameObject);
            }
        }
    }
}
