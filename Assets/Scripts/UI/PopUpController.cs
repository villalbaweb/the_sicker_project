using UnityEngine;
using TMPro;

namespace TheSicker.UI
{
    public class PopUpController : MonoBehaviour
    {
        // config
        [Range(0, 5)]
        [SerializeField] float disappearTimerConfig = 1f;
        
        [Range(0, 5)]
        [SerializeField] float dissapearSpeedConfig = 3f;
        
        [Range(0, 5)]
        [SerializeField] float increaseScaleAmount = 1f;

        [Range(0, 5)]
        [SerializeField] float decreaseScaleAmount = 1f;

        [SerializeField] Vector3 moveVectorConfig;
        [Range(0, 5)]
        [SerializeField] float moveVectorFactorConfig = 2.5f;

        // cache
        private TextMeshPro _textMesh;

        private float _disappearTimer;
        private float _dissapearSpeed;
        private Vector3 _moveVector;
        private Color _textColor;

        private void Awake()
        {
            _textMesh = GetComponent<TextMeshPro>();
        }

        private void Update()
        {
            MoveText();
            ScaleText();
            DissappearText();
        }

        private void MoveText()
        {
            transform.position += _moveVector * Time.deltaTime;
            _moveVector -= _moveVector * moveVectorFactorConfig * 0.5f * Time.deltaTime;
        }

        private void ScaleText()
        {
            if (_disappearTimer > disappearTimerConfig * 0.5)
            {
                transform.localScale += Vector3.one * increaseScaleAmount * Time.deltaTime;
            }
            else
            {
                transform.localScale -= Vector3.one * decreaseScaleAmount * Time.deltaTime;
            }
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
            gameObject.SetActive(false);
        }

        public void Setup(string message)
        {
            if (!_textMesh) return;

            _textMesh.SetText(message);
            _disappearTimer = disappearTimerConfig;
            _dissapearSpeed = dissapearSpeedConfig;
            _moveVector = moveVectorConfig * moveVectorFactorConfig;
            _textColor = _textMesh.color;
        }
    }
}
