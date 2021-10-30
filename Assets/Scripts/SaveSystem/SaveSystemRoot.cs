using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace TheSicker.SaveSystem
{
    public class SaveSystemRoot : MonoBehaviour
    {
        #region Public Methods

        public void Save(StateType stateType, string saveFile)
        {
            Dictionary<string, object> state = LoadFile(saveFile);
            CaptureState(stateType, state);
            SaveFile(saveFile, state);
        }

        public void Load(StateType stateType, string saveFile)
        {
            RestoreState(stateType, LoadFile(saveFile));
        }

        public void Delete(string saveFile)
        {
            File.Delete(GetPathFromSaveFile(saveFile));
        }

        #endregion

        #region Private Methods

        private Dictionary<string, object> LoadFile(string saveFile)
        {
            string path = GetPathFromSaveFile(saveFile);
            if (!File.Exists(path))
            {
                return new Dictionary<string, object>();
            }
            using (FileStream stream = File.Open(path, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return (Dictionary<string, object>)formatter.Deserialize(stream);
            }
        }

        private void SaveFile(string saveFile, object state)
        {
            string path = GetPathFromSaveFile(saveFile);
            print("Saving to " + path);
            using (FileStream stream = File.Open(path, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, state);
            }
        }

        private void CaptureState(StateType stateType, Dictionary<string, object> state)
        {
            foreach (SaveableGameObject saveableGameObject in FindObjectsOfType<SaveableGameObject>())
            {
                state[saveableGameObject.GetUniqueIdentifier()] = saveableGameObject.CaptureState(stateType);
            }
        }

        private void RestoreState(StateType stateType, Dictionary<string, object> state)
        {
            foreach (SaveableGameObject saveableGameObject in FindObjectsOfType<SaveableGameObject>())
            {
                string id = saveableGameObject.GetUniqueIdentifier();
                if (state.ContainsKey(id))
                {
                    saveableGameObject.RestoreState(stateType, state[id]);
                }
            }
        }

        private string GetPathFromSaveFile(string saveFile)
        {
            return Path.Combine(Application.persistentDataPath, saveFile + ".sav");
        }

        #endregion
    }
}
