using UnityEngine;

namespace TheSicker.Projectile
{
    public class ProjectilePoolObjectHandler : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            gameObject.SetActive(false);
        }
    }
}
