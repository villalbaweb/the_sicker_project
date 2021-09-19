using UnityEngine;
using TMPro;

namespace TheSicker.UI
{
    public class PopUpController : MonoBehaviour
    {
        // config
        [SerializeField] float disappearTimerConfig = 1f;
        [SerializeField] float dissapearSpeedConfig = 3f;

        // cache
        private TextMeshPro _textMesh;

        private float _disappearTimer;
        private float _dissapearSpeed;
        private Color _textColor;

        private void Awake()
        {
            _textMesh = GetComponent<TextMeshPro>();
        }

        private void Update()
        {
            MoveText();
            DissappearText();
        }

        private void MoveText()
        {
            float moveYSpeed = 2f;
            transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;
        }

        private void DissappearText()
        {
            _disappearTimer -= Time.deltaTime;
            if (_disappearTimer < 0)
            {
                _textColor.a -= _dissapearSpeed * Time.deltaTime;
                _textMesh.color = _textColor;

                if (_textColor.a < 0)
                {
                    PopUpCompleteHandle();
                }
            }
        }

        private void PopUpCompleteHandle()
        {
            // once this is configured to work with object pool
            // we need to setactive false
            Destroy(gameObject);
        }

        public void Setup(string message)
        {
            if (!_textMesh) return;

            _textMesh.SetText(message);
            _disappearTimer = disappearTimerConfig;
            _dissapearSpeed = dissapearSpeedConfig;
            _textColor = _textMesh.color;
        }
    }
}
