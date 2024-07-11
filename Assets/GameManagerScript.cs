using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    public GameObject enemy;

    public GameObject gameOverText;

    private bool gameOverFlag = false;

    public AudioSource hitAudioSource;

    public TextMeshProUGUI scoreText;

    private int score = 0;

    private int gameTimer = 0;

    public void GameOverStart()
    {
        gameOverText.SetActive(true);
        gameOverFlag = true;
    }

    public bool IsGameOver()
    {
        return gameOverFlag;
    }

    public void Hit()
    {
        hitAudioSource.Play();
        score += 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1980, 1080, false);
    }

    // Update is called once per frame
    void Update() 
    {
        scoreText.text = "SCORE " + score;

        if (gameOverFlag ==true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("TitleScene");
            }
        }

    }

    void FixedUpdate()
    {
        if (gameOverFlag == true)
        {
            return;
        }
        gameTimer++;
        int max = 50 - gameTimer / 100;
        int r = Random.Range(0, max);
        if (r == 0)
        {
            float x = Random.Range(-3.0f, 3.0f);
            Instantiate(enemy, new Vector3(x, 0, 10), Quaternion.identity);
        }
    }
}
