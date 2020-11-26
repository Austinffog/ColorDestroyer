using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class Points : MonoBehaviour
{
    public Text pointsAmount;
    public Text colorChosen;

    public static int points = 0;
    public int colorNum;
    public string colorPick;

    public float duration = 6f;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;

    public static int highScore;
    public Text highScoreAmount;

    public static int changeNum;

    //set colors in inspector
    public Color color1 = Color.white;
    public Color color2 = Color.white;
    public Color color3 = Color.white;
    public Color color4 = Color.white;
    public Color color5 = Color.white;
    public Color color6 = Color.white;
    public Color color7 = Color.white;

    public float timer = 0f;
    public Text timerValue;

    public GameObject GameOverMenu;
    public static bool GameIsPaused;
    public GameObject BlockInput;

    public GameObject FirstGoal, SecondGoal, ThirdGoal, FourthGoal, FifthGoal, Oops;

    public GameObject PauseMenu;

    private string storeId = "3570428";
    private string videoId = "rewardedVideo";

    private int no;

    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(storeId, false);
        StartCoroutine(ColorChosen());
        highScore = PlayerPrefs.GetInt("highScore", highScore);

        no = Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        pointsAmount.text = points.ToString();
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);

        colorNum = Random.Range(1, 8);

        if (points > highScore)
        {
            highScore = points;

        }
        highScoreAmount.text = "HS: " + highScore.ToString();
        PlayerPrefs.SetInt("highScore", highScore);
        PlayerPrefs.Save();

        timer += Time.deltaTime;
        timerValue.text = timer.ToString("f1");
        TimeChange();

        if (timer >= 50)
        {
            changeNum = Random.Range(1, 8);
            PointsChange();
        }

        if (points == 0)
        {
            FirstGoal.SetActive(true);
        }
        if (timer >= 5f)
        {
            FirstGoal.SetActive(false);
        }

        if (timer >= 51)
        {
            SecondGoal.SetActive(true);
        }
        if (timer >= 55)
        {
            SecondGoal.SetActive(false);
        }

        if (timer >= 151)
        {
            ThirdGoal.SetActive(true);
        }
        if (timer >= 155)
        {
            ThirdGoal.SetActive(false);
        }

        if (timer >= 501)
        {
            FourthGoal.SetActive(true);
            spawnLeastWait = 0f;
            spawnMostWait = 2f;
        }
        if (timer >= 505)
        {
            FourthGoal.SetActive(false);
        }

        if (timer >= 1001 & points >= 3500)
        {
            FifthGoal.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
            BlockInput.SetActive(true);
        }

        if (points == -15 & timer >= 0f)
        {
            Oops.SetActive(true);
        }
        if (points == -15 & timer >= 4f)
        {
            Oops.SetActive(false);
        }
    }

    IEnumerator ColorChosen()
    {

        while (true)
        {

            switch (colorNum) //set the colorchosen text based on the random number
            {
                case 1:
                    colorPick = "Blue";
                    colorChosen.text = colorPick.ToString();
                    break;
                case 2:
                    colorPick = "Green";
                    colorChosen.text = colorPick.ToString();
                    break;
                case 3:
                    colorPick = "Pink";
                    colorChosen.text = colorPick.ToString();
                    break;
                case 4:
                    colorPick = "Red";
                    colorChosen.text = colorPick.ToString();
                    break;
                case 5:
                    colorPick = "Yellow";
                    colorChosen.text = colorPick.ToString();
                    break;
                case 6:
                    colorPick = "Purple";
                    colorChosen.text = colorPick.ToString();
                    break;
                case 7:
                    colorPick = "Orange";
                    colorChosen.text = colorPick.ToString();
                    break;
            }

            switch (changeNum) //change the color of the text based on the random number
            {
                case 1:
                    colorChosen.color = color1;
                    break;
                case 2:
                    colorChosen.color = color2;
                    break;
                case 3:
                    colorChosen.color = color3;
                    break;
                case 4:
                    colorChosen.color = color4;
                    break;
                case 5:
                    colorChosen.color = color5;
                    break;
                case 6:
                    colorChosen.color = color6;
                    break;
                case 7:
                    colorChosen.color = color7;
                    break;
            }

            yield return new WaitForSeconds(spawnWait);
        }

    }

    public void PointsChange()
    {
        if (points >= 1000)
        {
            switch (changeNum)
            {
                case 1:
                    colorChosen.color = color1;
                    break;
                case 2:
                    colorChosen.color = color2;
                    break;
                case 3:
                    colorChosen.color = color3;
                    break;
                case 4:
                    colorChosen.color = color4;
                    break;
                case 5:
                    colorChosen.color = color5;
                    break;
                case 6:
                    colorChosen.color = color6;
                    break;
                case 7:
                    colorChosen.color = color7;
                    break;
            }
        }

    }

    public void TimeChange()
    {
        if (timer >= 50 & points < 350)
        {
            GameOver();
        }
        if (timer >= 150 & points < 1000)
        {
            GameOver();
        }
        if (timer >= 500 & points < 2500)
        {
            GameOver();
        }
        if (timer >= 1000 & points < 3500)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        GameOverMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        GameObject.Find("Objects").GetComponent<ColorObject>().spawnWait = 100;
        BlockInput.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameOverMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        timer = 0;
        points = 0;
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
        GameOverMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        timer = 0;
        points = 0;
    }

    public void Leave()
    {
        Application.Quit();
    }

    public void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        BlockInput.SetActive(true);
    }

    public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        BlockInput.SetActive(false);
    }

    public void Reward()
    {

        if (Advertisement.IsReady(videoId))
        {
            var options = new ShowOptions { resultCallback = Options };
            Advertisement.Show(videoId, options);
        }
    }

    private void Options(ShowResult result)
    {


        switch (result)
        {
            case ShowResult.Finished:

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                GameOverMenu.SetActive(false);
                Time.timeScale = 1f;
                GameIsPaused = false;

                if (no == 1)
                {
                    points = 15;
                    timer = 0f;
                }
                else if (no == 2)
                {
                    points = 25;
                    timer = 0f;
                }
                else if (no == 3)
                {
                    points = 3;
                    timer = 0f;
                }
                else
                {
                    points = -15;
                    timer = 0f;
                }

                break;
        }

    }

    public void Bonus()
    {

        if (Advertisement.IsReady(videoId))
        {
            var options = new ShowOptions { resultCallback = BonusOptions };
            Advertisement.Show(videoId, options);
        }

    }

    private void BonusOptions(ShowResult result)
    {
        switch (result)
        {

            case ShowResult.Finished:

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                GameOverMenu.SetActive(false);
                Time.timeScale = 1f;
                GameIsPaused = false;
                points = 100;
                timer = 0f;
                break;
        }
    }

    // Music by: Mickleness, (2015), Splash, Online(freesound.org/people/mickleness/sounds/316975/), Accessed[24 April 2020]
}
