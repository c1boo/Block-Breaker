using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
    //Config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject breakingSparkleVFX;
    [SerializeField] Sprite[] hitSprites;

    //Chaced vars
    LevelController level;

    //State vars
    int maxHits;
    int timesHit = 0;

    private void Start() {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks() {
        level = FindObjectOfType<LevelController>();
        if (tag == "Breakable")
            level.CountBlock();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        PlayCollisionSound();

        if (tag == "Breakable") {
            HandleHit();
        }

    }

    private void PlayCollisionSound() {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void HandleHit() {
        timesHit++;
        maxHits = hitSprites.Length;

        if (timesHit >= maxHits) {
            DestroyBlock();
        } else {
            ShowNextSpire();
        }
    }

    private void ShowNextSpire() {
        int spriteIndex = timesHit - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }

    private void DestroyBlock() {
        level.DecreaseNumberOfBlocks();
        FindObjectOfType<GameState>().AddToScore();
        PlayBreakingVFX();
        Destroy(gameObject);
    }

    private void PlayBreakingVFX() {
        GameObject sparklingVFX = Instantiate(breakingSparkleVFX, transform.position, transform.rotation);
        Destroy(sparklingVFX, 2f);
    }
}
