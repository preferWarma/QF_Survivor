using Lyf.ObjectPool;
using QFramework;
using UI;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// 用于收集物品的区域
    /// </summary>
    public class CollectableArea : MonoBehaviour
    {
        // 对简单逻辑的物品进行收集, 避免创建太多的脚本
        private void OnTriggerEnter2D(Collider2D other)
        {
            var otherTag = other.tag;

            switch (otherTag)
            {
                case "ExpObj":
                    Global.Exp.Value++;
                    AudioKit.PlaySound("GetExp");
                    ObjectPool.Instance.Recycle(other.gameObject);
                    break;
                
                case "MoneyObj":
                    Global.Money.Value++;
                    AudioKit.PlaySound("GetCoin");
                    ObjectPool.Instance.Recycle(other.gameObject);
                    break;
                
                case "RecoverObj":
                    Global.Hp.Value = Mathf.Min(Global.MaxHp.Value, Global.Hp.Value + 1);
                    AudioKit.PlaySound("RecoverHp");
                    // 绿色飘字+1
                    FloatTextController.Play(other.transform.position, "<color=green>+1</color>");
                    ObjectPool.Instance.Recycle(other.gameObject);
                    break;
            }
        }
    }
}
