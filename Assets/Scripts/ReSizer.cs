using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(SpriteRenderer))]
public class ReSizer : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _boxCollider;

    private void Start()
    {
        _spriteRenderer = transform.GetComponent<SpriteRenderer>();
        _boxCollider = transform.GetComponent<BoxCollider2D>();
        _boxCollider.size = _spriteRenderer.size;
    }
}
