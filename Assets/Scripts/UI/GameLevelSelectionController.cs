using TheSicker.Game;
using TheSicker.GameDifficulty;
using UnityEngine;

namespace TheSicker.UI
{
    public class GameLevelSelectionController : MonoBehaviour
    {
        // config params
        [SerializeField] DifficultyLevel difficultyLevel;
        [SerializeField] Animator animator;
        [SerializeField] AudioClip _clip;

        // cache
        GameDifficultyController _gameDifficultyController;
        GameSoundController _gameSoundController;

        private void Awake()
        {
            _gameDifficultyController = FindObjectOfType<GameDifficultyController>();
            _gameSoundController = FindObjectOfType<GameSoundController>();
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
            _gameSoundController.PlayClipAtCamera(_clip);
        }


        private void CheckLevelSelectedAnimation()
        {
            bool isSelected = _gameDifficultyController.GetSelectedDifficultyLevel() == difficultyLevel;
            animator.SetBool("Selected", isSelected);
        }
    }
}
