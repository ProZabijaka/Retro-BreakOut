using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;

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
        FindObjectOfType<GameSession>().AddToScore();
        PlayDestroyBlockSFX();
        Destroy(gameObject, 0);
        level.BlockDestroyed();
        TriggerSparklesVFX();
    }

    private void PlayDestroyBlockSFX()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 0.5f);
    }
}
