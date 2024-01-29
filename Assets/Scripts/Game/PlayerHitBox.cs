using QFramework;
using UI;
using UnityEngine;

namespace Game
{
    public class PlayerHitBox : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                // TODO: 玩家受伤
                UIKit.OpenPanel<UIGameOver>();
            }
        }
    }
}