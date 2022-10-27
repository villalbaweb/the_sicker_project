using TheSicker.Game;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TheSicker.UI
{
    public class BaseButtonHandler : MonoBehaviour, IPointerDownHandler
    {
        // config
        [SerializeField] AudioClip clip;
        [SerializeField] string buttonText;
        [SerializeField] Animator animator;

        // cache
        GameSoundController _gameSoundController;

        private void Awake()
        {
            _gameSoundController = FindObjectOfType<GameSoundController>();
        }


        #region IPointerDownHandler Implementation 

        public void OnPointerDown(PointerEventData eventData)
        {
            _gameSoundController.PlayClipAtCamera(clip);
            animator.SetTrigger("buttonClicked");
        }

        #endregion
    }
}
