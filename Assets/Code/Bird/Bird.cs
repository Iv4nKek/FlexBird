using System;
using System.Collections;
using System.Collections.Generic;
using Code;
using Code.Level;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private BirdCollisionHandler _collisionHandler;

    private void Start()
    {
        _collisionHandler.OnWallCollision += Flip;
        GameState.Instance.OnLevelStart += OnLevelStart;
    }

    private void OnDestroy()
    {
        _collisionHandler.OnWallCollision -= Flip;
        GameState.Instance.OnLevelStart -= OnLevelStart;
    }

    private void OnLevelStart()
    {
        _renderer.flipX = false;
    }
    private void Flip()
    {
        _renderer.flipX = !_renderer.flipX;
    }
}
