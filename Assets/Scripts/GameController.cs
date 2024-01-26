using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject[] trapFrefab;
    [SerializeField] GameObject[] fruitFrefab;
    [SerializeField] float trapSpawnTime;
    [SerializeField] float fruitSpawnTime;
    [SerializeField] float maxX, minX;

    public static int score;
    public static float speedRate = 1;

    [SerializeField] private GameObject tapText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    [SerializeField] AudioSource deathSound;

    private bool started = false;

    void Start()
    {
       score = 0;
       Application.targetFrameRate = 60;
    }

    void Update(){
        if(Input.GetMouseButtonDown(0) && !started)
        {
            StartCoroutine(TrapSpawn());
            StartCoroutine(FruitSpawn());
            started = true;
            tapText.SetActive(false);
        }

        scoreText.text = score.ToString();
        highScoreText.text = "High score: " + PlayerPrefs.GetInt("HighScore").ToString();

        UpdateSpeedRate();
        UpdateHighScore();
        CheckDead();
    }

    private void UpdateSpeedRate()
    {
        speedRate = (score + 100) / 100f;
    }

    private void UpdateHighScore()
    {
        int maxs = PlayerPrefs.GetInt("HighScore");
        if(score > maxs)
        {
            PlayerPrefs.SetInt("HighScore",score);
        }
    }

    IEnumerator TrapSpawn()
    {
        while(true)
        {
            float posX = Random.Range(maxX,minX);
            Vector3 pos = new Vector3(posX,transform.position.y);
            GameObject trap = Instantiate(trapFrefab[Random.Range(0,trapFrefab.Length)],pos,Quaternion.identity);
            yield return new WaitForSeconds(trapSpawnTime);
        }
    }

    IEnumerator FruitSpawn()
    {
        while(true)
        {
            float posX = Random.Range(maxX,minX);
            Vector3 pos = new Vector3(posX,transform.position.y);
            GameObject fruit = Instantiate(fruitFrefab[Random.Range(0,fruitFrefab.Length)],pos,Quaternion.identity);
            yield return new WaitForSeconds(fruitSpawnTime);
        }
    }

    private void CheckDead()
    {
        if(Player.isDead)
        {
            //deathSound.Play();
            Invoke("LoadScene", 0.3f);
        }
    }

    private void LoadScene()
    {
        SceneManager.LoadScene("Game");
    }
}
