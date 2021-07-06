using System.Collections;
using System.Collections.Generic;

using UnityEngine.SceneManagement;
using UnityEngine;

public class ScoreTrack : MonoBehaviour
{
    public int lives, lvlCurrency, gameGold;
    private string currentScene;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene().name;
    }

    public void setCurrency(int score)
    {
        this.lvlCurrency = score;
    }
    public int getCurrency()
    {
        return this.lvlCurrency;
    }
    public void setLives(int lives)
    {
        this.lives = lives;
    }
    public int getLives()
    {
        if (this.lives <= 0)
        {
            setLives(5);
            SceneManager.LoadScene("Game Over");
        }

        return this.lives;
    }
}
