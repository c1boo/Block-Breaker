using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
    //Config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject breakingSparkleVFX;

    //Chaced params
    LevelController level;
    GameState gameState;

    private void Start() {
        level = FindObjectOfType<LevelController>();
        level.CountBlock();

        gameState = FindObjectOfType<GameState>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        DestroyBlock();
    }

    private void DestroyBlock() {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);

        level.DeleteBlock();
        gameState.AddToScore();
        PlayBreakingVFX();
    }

    private void PlayBreakingVFX() {
        GameObject sparklingVFX = Instantiate(breakingSparkleVFX, transform.position, transform.rotation);
        Destroy(sparklingVFX, 2f);
    }
}
