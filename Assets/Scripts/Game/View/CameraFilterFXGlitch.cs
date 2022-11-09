using System.Collections;
using UnityEngine;

namespace Game
{
    public class CameraFilterFXGlitch : MonoBehaviour
    {
        #region Variables
        private Shader _shader;
        private float _timeX = 1.0f;
        private Material _material;
        [Range(0, 1)]
        [SerializeField] private float _maxGlitch = 1.0f;
        private float _glitch;
        [SerializeField] private float _glitchTime;
        #endregion

        #region Properties
        private Material Material => _material ??= new Material(_shader)
        {
            hideFlags = HideFlags.HideAndDontSave
        };
        #endregion
        private void Start()
        {
            _shader = Shader.Find("CameraFilter/FX_Glitch");
        }

        public void ExecuteGlitch()
        {
            StopAllCoroutines();
            StartCoroutine(GlitchCoroutine());
        }

        private IEnumerator GlitchCoroutine()
        {
            _glitch = _maxGlitch;
            yield return new WaitForSeconds(_glitchTime);
            _glitch = 0;
        }

        private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
        {
            if (_shader != null)
            {
                _timeX += Time.deltaTime;

                if (_timeX > 100)
                {
                    _timeX = 0;
                }

                var screenResolution = new Vector4(sourceTexture.width, sourceTexture.height, 0.0f, 0.0f);

                Material.SetFloat("_TimeX", _timeX);
                Material.SetFloat("_Glitch", _glitch);
                Material.SetVector("_ScreenResolution", screenResolution);
                Graphics.Blit(sourceTexture, destTexture, Material);
            }
            else
            {
                Graphics.Blit(sourceTexture, destTexture);
            }
        }

        private void OnDisable()
        {
            if (_material)
            {
                DestroyImmediate(_material);
            }
        }
    }
}