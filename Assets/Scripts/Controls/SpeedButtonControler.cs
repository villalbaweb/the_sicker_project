using TheSicker.Player;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TheSicker.Controls
{
    public class SpeedButtonControler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        // cache
        PlayerMover _playerMover;
         
        private void Awake()
        {
            _playerMover = FindObjectOfType<PlayerMover>();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _playerMover?.MoveBtnDown();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _playerMover.MoveBtnUp();
        }


    }
}
