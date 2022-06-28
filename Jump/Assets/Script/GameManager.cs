using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameover = false; 
    public Text scoreText; 
    public GameObject gameoverUI; 

    private float ScoreTime = 0;
    // Start is called before the first frame update
    void Awake()
    {

        if (instance == null)
        {

            instance = this;
        }
        else
        {

            Debug.LogWarning("씬에 두개 이상의 게임 매니저가 존재합니다!");
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!isGameover)
        {
            
            ScoreTime += Time.deltaTime;
            scoreText.text = "Time : " + ScoreTime.ToString("F2");
        }

        if (isGameover && Input.GetMouseButtonDown(0))
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void AddTime(int newScore)
    {


    }

    
    public void OnPlayerDead()
    {

        isGameover = true;

        gameoverUI.SetActive(true);
    }
}
