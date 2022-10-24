using TheSicker.GameDifficulty;
using UnityEngine;

namespace TheSicker.UI
{
    public class GameLevelSelectionController : MonoBehaviour
    {
        // config params
        [SerializeField] DifficultyLevel difficultyLevel;
        [SerializeField] Animator animator;

        // cache
        GameDifficultyController _gameDifficultyController;

        private void Awake()
        {
            _gameDifficultyController = FindObjectOfType<GameDifficultyController>();
        }

        // Update is called once per frame
        void Update()
        {
            CheckLevelSelectedAnimation();
        }

        public void SetDifficultyLevelClicked()
        {
            if (!_gameDifficultyController) return;

            _gameDifficultyController.SetDifficultyLevel(difficultyLevel);
        }


        private void CheckLevelSelectedAnimation()
        {
            bool isSelected = _gameDifficultyController.GetSelectedDifficultyLevel() == difficultyLevel;
            animator.SetBool("Selected", isSelected);
        }
    }
}
