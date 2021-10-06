using UnityEngine;

namespace TheSicker.SaveSystem
{
    public class SaveSystemaWrapper : MonoBehaviour
    {
        private const string DEFAULT_SAVE_FILE = "sicker_game_advance";

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
            _saveSystemRoot.Save(DEFAULT_SAVE_FILE);
        }

        public void Load()
        {
            _saveSystemRoot.Load(DEFAULT_SAVE_FILE);
        }

        public void Delete()
        {
            _saveSystemRoot.Delete(DEFAULT_SAVE_FILE);
        }

        #endregion
    }
}
