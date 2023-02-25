using System.Collections.Generic;
using System.Linq;
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

            Dictionary<string, object> fullFile = _saveSystemWrapper.GetFullMaxXpSavedFile();  // This can be retrieved just once Lazy Loading

            string playerId = GetPlayerId(fullFile);

            maxScore.text = playerId is null ? "0" : RetrieveMaxPoints(fullFile, playerId);
        }

        private string RetrieveMaxPoints(Dictionary<string, object> fullFile, string playerId)
        {
            Dictionary<string, object> maxXps = fullFile[playerId] as Dictionary<string, object>;

            var maxXpKeyForDifficulty = maxXps.FirstOrDefault(x => x.Key.Contains(difficultyLevel.ToString())).Key;

            return maxXpKeyForDifficulty is null
                ? "0"
                : maxXps[maxXpKeyForDifficulty].ToString();
        }


        private StateType SetStateTypeBasedOnDifficulty()
        {
            switch (difficultyLevel)
            {
                case DifficultyLevel.Easy:
                    return StateType.MaxXpEasy;

                case DifficultyLevel.Medium:
                    return StateType.MaxXpMedium;

                case DifficultyLevel.Hard:
                    return StateType.MaxXpHard;
            }

            return StateType.MaxXpEasy;
        }


        private string GetPlayerId(Dictionary<string, object> fullFile)
        {
            var stateType = SetStateTypeBasedOnDifficulty().ToString();

            foreach (string key in fullFile.Keys)
            {
                var availableKeys = (Dictionary<string, object>)fullFile[key];
                foreach (var value in availableKeys)
                {
                    if (value.Key.Contains(stateType))
                    {
                        return key;
                    }
                }
            }

            return null;
        }
    }
}
