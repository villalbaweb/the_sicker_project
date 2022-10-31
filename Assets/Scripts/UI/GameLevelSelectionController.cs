using TheSicker.Game;
using TheSicker.GameDifficulty;
using TheSicker.SaveSystem;
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
        SaveSystemWrapper _saveSystemWrapper;

        private void Awake()
        {
            _gameDifficultyController = FindObjectOfType<GameDifficultyController>();
            _gameSoundController = FindObjectOfType<GameSoundController>();
            _saveSystemWrapper = FindObjectOfType<SaveSystemWrapper>();
        }

        private void Start()
        {
            SetLevelText();
            SetMaxXpText();
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

        private void SetMaxXpText()
        {
            if(!_saveSystemWrapper) return;

            var fullFile = _saveSystemWrapper.GetFullMaxXpSavedFile();
        }

    }
}
