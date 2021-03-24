using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] int highScoreNum;
    
    [SerializeField] Text scoreText;
    [SerializeField] int currentScore = 0;
    public Text highscore;
    // Give gameobject numbers to count
    // Good idea to keep strings like this in a field, to avoid typos later.
    private const string highScoreKey = "HighScore";
    public static ScoreKeeper instance;
    void Awake() {
        
        if (instance != null){
            Destroy(this.gameObject);
        }
        else{
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    // set build of Score Text
    private void Start()
    {
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        currentScore = 0;
        ResetGameScore();
        scoreText.text = "Score: " + currentScore.ToString();
        highScoreNum = PlayerPrefs.GetInt("HighScore");
        Debug.Log(highScoreNum);
    }
	
	void Update()
    {
        scoreText.text = "Score: " + currentScore.ToString();
        PlayerPrefs.GetInt("Score",currentScore).ToString();
        SetHighScore(); 
    }
    public void ResetGameScore(){
        PlayerPrefs.SetInt("Score",0);
        currentScore = 0;
    }
    private void OnEnable() {
        SceneManager.sceneLoaded += OnScreenChange;
    }
    private void OnDisable() {
        SceneManager.sceneLoaded -= OnScreenChange;
        // Set our high score.
        PlayerPrefs.SetInt (highScoreKey, highScoreNum);
        // Save our data.
        PlayerPrefs.Save();
    
        // TODO: Delete me, for debugging only!
        //Debug.Log("I'm being Disabled! The high score is currently: " + highScoreNum);
  
    }
    private void OnScreenChange(Scene scene, LoadSceneMode loadSceneMode){
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        ResetGameScore();
    }
    // Add score when the block is destroyed
    public void AddToScore(int score)
    {
        currentScore += score;
        scoreText.text = "Score: " + currentScore.ToString();
    }
    public void SetHighScore()
    {
        // Check if our new score is greater than our previous high score.
        if (currentScore > highScoreNum)
        {
            // Change the high score to the new current value.
            highScoreNum = currentScore;
            // Update the high score UI text.
            //highScoreText.text = highScore.ToString();

            // TODO: Delete me, unless for some odd reason I am needed...
            PlayerPrefs.SetInt (highScoreKey, highScoreNum);
            PlayerPrefs.Save();
        } 
    }
}
