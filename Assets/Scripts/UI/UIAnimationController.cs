using DG.Tweening;
using UnityEngine;

namespace UI
{
    public class UIAnimationController : MonoBehaviour
    {
        
        public static void DoOpen(GameObject obj, float duration = 0.3f, Ease openEase = Ease.OutCubic)
        {
            // 先设置初始状态
            obj.transform.localScale = Vector3.zero;
				
            obj.transform.DOScale(Vector3.one, duration)
                .SetEase(openEase)
                .OnStart(() => obj.SetActive(true));
        }
        
        public static void DoClose(GameObject obj, float duration = 0.3f, Ease closeEase = Ease.InQuad)
        {
            obj.transform.DOScale(Vector3.zero, duration)
                .SetEase(closeEase)
                .OnComplete(() => obj.SetActive(false));
        }
    }
}