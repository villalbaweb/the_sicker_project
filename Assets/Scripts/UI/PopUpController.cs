using UnityEngine;
using TMPro;
using TheSicker.Core;

namespace TheSicker.UI
{
    public class PopUpController : MonoBehaviour, IPooledObject
    {
        // config
        [SerializeField] float disappearTimerConfig = 1f;
        [SerializeField] float dissapearSpeedConfig = 3f;
        [SerializeField] float increaseScaleAmount = 1f;
        [SerializeField] float decreaseScaleAmount = 1f;
        [SerializeField] float moveVectorFactorConfig = 2.5f;

        // cache
        private TextMeshPro _textMesh;

        private float _disappearTimer;
        private float _dissapearSpeed;
        private Vector3 _moveVector;
        private Vector3 _initialScale;
        private bool _isRunning;

        private void Awake()
        {
            _textMesh = GetComponent<TextMeshPro>();
            _initialScale = transform.localScale;
        }

        private void Update()
        {
            if (!_isRunning) return;

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
                _textMesh.alpha -= _dissapearSpeed * Time.deltaTime;

                if (_textMesh.alpha < 0)
                {
                    PopUpCompleteHandle();
                }
            }
        }

        private void PopUpCompleteHandle()
        {
            _isRunning = false;
            gameObject.SetActive(false);
        }

        public void Setup(string message, Vector3 rotation)
        {
            if (!_textMesh) return;

            _textMesh.SetText(message);

            _isRunning = true;

            _moveVector = Quaternion.Euler(rotation) * Vector3.right * moveVectorFactorConfig;
        }

        public void OnObjectSpawn()
        {
            _textMesh.alpha = 1;
            _disappearTimer = disappearTimerConfig;
            _dissapearSpeed = dissapearSpeedConfig;
            transform.localScale = _initialScale;
        }
    }
}
