using UnityEngine;
using TMPro;

namespace TheSicker.UI
{
    public class PopUpController : MonoBehaviour
    {
        // cache
        private TextMeshPro _textMesh;

        private void Awake()
        {
            _textMesh = GetComponent<TextMeshPro>();
        }

        public void Setup(string message)
        {
            if (!_textMesh) return;

            _textMesh.SetText(message);
        }
    }
}
