using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0;
    public float lifeTime = 1.0f;
    public float startTime = 3.0f;

    public int hitBlockScore = 10;
    public float missBlockLife = 0.1f;
    public float wrongBlockLife = 0.08f;
    public float lifeRegenRate = 0.1f;

    public VelocityTracker leftSwordTracker;
    public VelocityTracker rightSwordTracker;
    public float swordHitVelocityThreshold = 0.5f;

    public bool canFail = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void AddScore()
    {
        score += hitBlockScore;
        GameUI.instance.UpdateScore();
    }

    public void MissBlock()
    {
        lifeTime -= missBlockLife;
    }

    public void HitWrongBlock()
    {
        lifeTime -= wrongBlockLife;
    }

    private void Update()
    {
        lifeTime = Mathf.MoveTowards(lifeTime, 1.0f, lifeRegenRate * Time.deltaTime);
        GameUI.instance.UpdateHealth();

        if (canFail && lifeTime <= 0)
        {
            LoseGame();
        }
    }

    public void WinGame()
    {
        SceneManager.LoadScene(0);
    }

    public void LoseGame()
    {
        SceneManager.LoadScene(0);
    }
}
