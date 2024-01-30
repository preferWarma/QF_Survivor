using QFramework;
using UI;
using UnityEngine;

namespace Game
{
    public class PlayerHitBox : MonoBehaviour
    {
        private float _timer;   // 无敌时间
        private bool _isHurt;   // 是否处于受击状态
        
        private SpriteRenderer _spriteRenderer; // 人物图像

        private void Start()
        {
            _isHurt = false;
            _spriteRenderer = transform.parent.GetComponentInChildren<SpriteRenderer>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_isHurt) return;    // 给一个受击的无敌帧用于显示受击动画
            
            if (other.CompareTag("Enemy"))
            {
                Global.Hp.Value--;
                if (Global.Hp.Value <= 0)
                {
                    UIKit.OpenPanel<UIGameOver>();
                    AudioKit.PlaySound("PlayerDie");
                }
                else
                {
                    AudioKit.PlaySound("PlayerGetHurt");
                    
                    // 简易受伤动画
                    _isHurt = true;
                    _spriteRenderer.color = Color.red;
                    ActionKit.Delay(0.5f, () =>
                    {
                        if (_spriteRenderer == null) return;
                        _spriteRenderer.color = Color.white;
                        _isHurt = false;
                    }).Start(this);
                }
            }
        }
    }
}