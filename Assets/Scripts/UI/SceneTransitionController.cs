using UnityEngine;

namespace TheSicker.UI
{
    public class SceneTransitionController : MonoBehaviour
    {
        // config

        [SerializeField] Animator animator;


        public void StartSceneAwayTransitionAnimation()
        {
            animator.SetTrigger("StartAwayTransition");
        }
    }
}
