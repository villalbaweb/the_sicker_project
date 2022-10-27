using TheSicker.Game;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TheSicker.UI
{
    public class BaseButtonHandler : MonoBehaviour, IPointerDownHandler
    {
        // config
        [SerializeField] AudioClip clip;
        [SerializeField] string buttonText;

        [Header("Base Config")]
        [SerializeField] Animator animator;
        [SerializeField] TextMeshProUGUI text;

        // cache
        GameSoundController _gameSoundController;

        private void Awake()
        {
            _gameSoundController = FindObjectOfType<GameSoundController>();

            text.text = buttonText;
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
