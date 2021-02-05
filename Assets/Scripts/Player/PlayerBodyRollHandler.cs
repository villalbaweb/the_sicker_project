using UnityEngine;

namespace TheSicker.Player
{
    public class PlayerBodyRollHandler : MonoBehaviour
    {
        // config
        [SerializeField] Transform bodyTransform = null;
        [SerializeField] float rollFactor = 40f;

        // Cached components refs
        PlayerRotation _playerRotation;

        // state
        float baseZPos = 0;
        Vector3 originalRotation;

        // Start is called before the first frame update
        void Awake()
        {
            _playerRotation = GetComponent<PlayerRotation>();
            originalRotation = bodyTransform.localRotation.eulerAngles;
        }

        private void Update()
        {
            CalculatePlayerRoll();
        }

        private void CalculatePlayerRoll()
        {
            float playerZPos = _playerRotation.transform.localRotation.z;


            if (Mathf.Approximately(baseZPos, playerZPos))
            {
                bodyTransform.localRotation = Quaternion.Euler(originalRotation.x, originalRotation.y, originalRotation.z);
            }
            else if (baseZPos > playerZPos)
            {
                bodyTransform.localRotation = Quaternion.Euler(originalRotation.x, originalRotation.y, originalRotation.z - rollFactor);
            }
            else
            {
                bodyTransform.localRotation = Quaternion.Euler(originalRotation.x, originalRotation.y, originalRotation.z + rollFactor);
            }

            baseZPos = playerZPos;

            return;
        }
    }
}