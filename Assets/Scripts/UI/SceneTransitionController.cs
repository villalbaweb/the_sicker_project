using UnityEditor.Animations;
using UnityEngine;

namespace TheSicker.UI
{
    public class SceneTransitionController : MonoBehaviour
    {
        // config

        [SerializeField] Animator animator;


        public void StartSceneTransitionAnimation()
        {
            animator.SetTrigger("StartTransition");
        }
    }
}
