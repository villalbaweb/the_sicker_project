using UnityEngine;

namespace TheSicker.Core
{
    public class OnCollisionWithDelimiterTurnAround : MonoBehaviour
    {
        // config
        [SerializeField] string tagToIdentifyAndTurn = "";

        //Just hit another collider 2D
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.tag != tagToIdentifyAndTurn) return;
            
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, Random.Range(45, 360));
        }
    }
}