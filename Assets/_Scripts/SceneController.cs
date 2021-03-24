using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    [SerializeField] int score, highScoreNum;
    
    [SerializeField] Text scoreText;
    [SerializeField] int currentScore = 0;
    public Text highscore;
    // Give gameobject numbers to count
    public static SceneController instance;
    void Awake() {
        
        if (instance == null){
            instance = this;
        }
        else{
            if (instance != this) {
                Destroy(this);
            }
            
        }
        DontDestroyOnLoad(this.gameObject);
    }
        private void Start()
    {
        scoreText = GameObject.Find("HUD/Score").GetComponent<Text>();
        score = 0;
        ResetGameScore();
        scoreText.text = "Score: " + currentScore.ToString();
        highScoreNum = PlayerPrefs.GetInt("HighScore");
    }
	
	// Update is called once per frame
	void Update()
    {
        
        score = currentScore;
        scoreText.text = "Score: " + score.ToString();
        PlayerPrefs.GetInt("Score",score).ToString();
        SetHighScore(score);
    }
    public void ResetGameScore(){
        PlayerPrefs.SetInt("Score",0);
        score = 0;
    }

    // Add score when the block is destroyed
    public void AddToScore(int score)
    {
        currentScore += score;
        scoreText.text = "Score: " + currentScore.ToString();
    }
    public static void SetHighScore(int score)
    {
        if (score > PlayerPrefs.GetInt("HighScore", score))
        {
            
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
    
}
