using UnityEngine;

namespace Game.PowerUpItem
{
    // 用于实现自动收集功能创建的脚本
    public class MoneyOrExp : MonoBehaviour
    {
        private bool _isAutoCollect;
        private Player _player;
        
        private void Start()
        {
            _player = FindObjectOfType<Player>();
        }

        private void Update()
        {
            if (_isAutoCollect)
            {
                Collect(gameObject);
            }
        }
        
        // 自动追踪到Player的位置, 实现简易的自动收集动画
        private void Collect(GameObject obj, float speed = 12f)
        {
            if (!_player) return;
            var dir = (_player.transform.position - obj.transform.position).normalized;
            obj.transform.Translate(dir * (Time.deltaTime * speed));
        }
        
        public void AutoCollect(bool isAutoCollect)
        {
            _isAutoCollect = isAutoCollect;
        }

        private void OnDisable()
        {
            _isAutoCollect = false;
        }
    }
}