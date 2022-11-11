using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollMaterial : MonoBehaviour
{
    [SerializeField] private Vector2 _offset;
    [SerializeField] private Vector2 _scroll;
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        _offset += _scroll * Time.deltaTime;
        _renderer.material.SetTextureOffset("_MainTex", _offset);
    }
}
