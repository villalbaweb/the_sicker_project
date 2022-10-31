using TheSicker.Game;
using TheSicker.GameDifficulty;
using TMPro;
using UnityEngine;

namespace TheSicker.UI
{
    public class GameLevelSelectionController : MonoBehaviour
    {
        // config params
        [SerializeField] DifficultyLevel difficultyLevel;
        [SerializeField] Animator animator;
        [SerializeField] AudioClip clip;
        [SerializeField] TextMeshProUGUI levelName;
        [SerializeField] TextMeshProUGUI maxScore;

        // cache
        GameDifficultyController _gameDifficultyController;
        GameSoundController _gameSoundController;

        private void Awake()
        {
            _gameDifficultyController = FindObjectOfType<GameDifficultyController>();
            _gameSoundController = FindObjectOfType<GameSoundController>();

            SetLevelText();
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
            _gameSoundController.PlayClipAtCamera(clip);
        }


        private void CheckLevelSelectedAnimation()
        {
            bool isSelected = _gameDifficultyController.GetSelectedDifficultyLevel() == difficultyLevel;
            animator.SetBool("Selected", isSelected);
        }

        private void SetLevelText()
        {
            levelName.text = difficultyLevel.ToString();
        }

    }
}
