using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
    //Config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject breakingSparkleVFX;

    //Chaced params
    LevelController level;

    private void Start() {
        level = FindObjectOfType<LevelController>();
        level.CountBlock();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        DestroyBlock();
    }

    private void DestroyBlock() {
        PlayCollisionSound();
        level.DeleteBlock();
        FindObjectOfType<GameState>().AddToScore();
        PlayBreakingVFX();
    }

    private void PlayCollisionSound() {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
    }

    private void PlayBreakingVFX() {
        GameObject sparklingVFX = Instantiate(breakingSparkleVFX, transform.position, transform.rotation);
        Destroy(sparklingVFX, 2f);
    }
}
