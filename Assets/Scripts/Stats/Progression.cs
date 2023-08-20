using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TheSicker.Stats
{
    [CreateAssetMenu(fileName = "Progression", menuName = "Stats/New Progression", order = 0)]
    public class Progression : ScriptableObject
    {
        // config
        [SerializeField] ProgressionCharacterClass[] characterClasses = null;

        // private properties
        Dictionary<CharacterClass, Dictionary<Stat, float[]>> lookupTable = null;

        #region Public Methods

        public float GetStat(Stat stat, CharacterClass characterClass, int level)
        {
            BuildLookup();

            float statValue = 0;

            if (lookupTable.ContainsKey(characterClass) && lookupTable[characterClass].ContainsKey(stat))
            {
                float[] statLevels = lookupTable[characterClass][stat];

                int maxStatAvailableLevel = statLevels.Length;
                statValue = maxStatAvailableLevel >= level ? statLevels[level == 0 ? 0 : level - 1] : statLevels[maxStatAvailableLevel - 1];
            }

            return statValue;
        }

        public int GetLevels(Stat stat, CharacterClass characterClass)
        {
            BuildLookup();

            float[] levels = lookupTable[characterClass][stat];

            return levels.Count();
        }

        #endregion


        #region Private Methods

        private void BuildLookup()
        {
            if (lookupTable != null) return;

            lookupTable = new Dictionary<CharacterClass, Dictionary<Stat, float[]>>();

            foreach (ProgressionCharacterClass progressionClass in characterClasses)
            {
                Dictionary<Stat, float[]> statsLookupTable = new Dictionary<Stat, float[]>();
                foreach (ProgessionStat progressionStat in progressionClass.stats)
                {
                    statsLookupTable.Add(progressionStat.stat, progressionStat.levels);
                }

                lookupTable.Add(progressionClass.character, statsLookupTable);
            }
        }

        #endregion
    }
}
