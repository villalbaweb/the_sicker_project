using UnityEngine;

namespace TheSicker.SaveSystem
{
    public class SaveSystemWrapper : MonoBehaviour
    {
        private const string GENERAL_SAVE_FILE = "sicker_game_advance";
        private const string MAX_XP_SAVE_FILE = "sicker_game_max_points";

        // cache
        SaveSystemRoot _saveSystemRoot;

        private void Awake()
        {
            _saveSystemRoot = GetComponent<SaveSystemRoot>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                Load();
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                Save();
            }

            if (Input.GetKeyDown(KeyCode.Delete))
            {
                Delete();
            }
        }

        #region Public Methods

        public void Save()
        {
            _saveSystemRoot.Save(StateType.General, GENERAL_SAVE_FILE);
        }

        public void Load()
        {
            _saveSystemRoot.Load(StateType.General, GENERAL_SAVE_FILE);
        }

        public void Delete()
        {
            _saveSystemRoot.Delete(GENERAL_SAVE_FILE);
            _saveSystemRoot.Delete(MAX_XP_SAVE_FILE);
        }

        public void SaveMaxXpPoint(StateType stateType)
        {
            _saveSystemRoot.Save(stateType, MAX_XP_SAVE_FILE);
        }

        public void GetMaxXpPoint(StateType stateType)
        {
            _saveSystemRoot.Load(stateType, MAX_XP_SAVE_FILE);
        }

        #endregion
    }
}
