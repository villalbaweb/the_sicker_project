using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace TheSicker.SaveSystem
{
    [ExecuteAlways]
    public class SaveableGameObject : MonoBehaviour, ISaveableGameObject
    {
        [SerializeField] string uniqueIdentifier = "";

        // This needs to be static in order to be available from the editor all the time
        static Dictionary<string, SaveableGameObject> globalLookup = new Dictionary<string, SaveableGameObject>();

        #region Public Methods

        public object CaptureState(StateType stateType)
        {
            Dictionary<string, object> state = new Dictionary<string, object>();
            foreach (ISaveableComponent saveableComponent in GetComponents<ISaveableComponent>())
            {
                state[saveableComponent.GetType().ToString()] = saveableComponent.CaptureState(stateType);
            }
            return state;
        }

        public string GetUniqueIdentifier()
        {
            return uniqueIdentifier;
        }

        public void RestoreState(StateType stateType, object state)
        {
            Dictionary<string, object> stateDict = (Dictionary<string, object>)state;
            foreach (ISaveableComponent saveableComponent in GetComponents<ISaveableComponent>())
            {
                string typeString = saveableComponent.GetType().ToString();
                if (stateDict.ContainsKey(typeString))
                {
                    saveableComponent.RestoreState(stateType, stateDict[typeString]);
                }
            }
        }

        #endregion

        #region Private Methods

#if UNITY_EDITOR
        private void Update()
        {
            if (Application.IsPlaying(gameObject)) return;
            if (string.IsNullOrEmpty(gameObject.scene.path)) return;

            SerializedObject serializedObject = new SerializedObject(this);
            SerializedProperty property = serializedObject.FindProperty("uniqueIdentifier");

            if (string.IsNullOrEmpty(property.stringValue) || !IsUnique(property.stringValue))
            {
                property.stringValue = System.Guid.NewGuid().ToString();
                serializedObject.ApplyModifiedProperties();
            }

            globalLookup[property.stringValue] = this;
        }
#endif

        private bool IsUnique(string candidate)
        {
            if (!globalLookup.ContainsKey(candidate)) return true;

            if (globalLookup[candidate] == this) return true;

            if (globalLookup[candidate] == null)
            {
                globalLookup.Remove(candidate);
                return true;
            }

            if (globalLookup[candidate].GetUniqueIdentifier() != candidate)
            {
                globalLookup.Remove(candidate);
                return true;
            }

            return false;
        }

        #endregion
    }
}
