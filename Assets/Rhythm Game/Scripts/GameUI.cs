using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUI : MonoBehaviour
{
    public static GameUI instance;

    public TextMeshProUGUI scoreText;
    public Image lifetimeBar;

    private void Awake()
    {
        if (instance == null) 
        {
            instance = this;
        }           
    }

    public void UpdateScore()
    {
        scoreText.text = $" Score:\n {GameManager.instance.score.ToString()}";
    }

    public void UpdateHealth()
    {
        lifetimeBar.fillAmount = GameManager.instance.lifeTime;
    }
}
