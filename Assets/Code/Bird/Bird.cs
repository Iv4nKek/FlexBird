using System;
using System.Collections;
using System.Collections.Generic;
using Code;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private BirdCollisionHandler _collisionHandler;

    private void Start()
    {
        _collisionHandler.OnWallCollision += Flip;
    }

    private void Flip()
    {
        _renderer.flipX = !_renderer.flipX;
    }
}
