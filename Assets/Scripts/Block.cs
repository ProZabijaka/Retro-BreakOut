﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;


    // Cached reference
    Level level;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.BreakableBlocksAmount();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject, 0);
        level.BlockDestroyed();
    }
}
