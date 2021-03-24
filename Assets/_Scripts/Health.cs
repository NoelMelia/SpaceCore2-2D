using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;
    [SerializeField]public Text amountOfHealth;
    [SerializeField] private GameObject gameOverPanel;
    public HealthBar healthBar;
    public static Health instance;
    private ScoreKeeper sc;
    // Start is called before the first frame update

    private void Awake() {
        if (instance != null){
            Destroy(this.gameObject);
        }
        else{
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    void Start()
    {
        
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        amountOfHealth.text =  maxHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        amountOfHealth.text = currentHealth.ToString();
        if(currentHealth <= 0)
        {
            EndGame(); 
            
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        amountOfHealth.text = currentHealth.ToString();
    }

    private void EndGame()
    {
        Time.timeScale = 0f;
        Debug.Log("Game End");
        //gameOverPanel.SetActive(true);
        //sc.ResetGameScore();
        ScoreKeeper.instance.ResetGameScore();
        //sc.ResetGameScore();
        gameOverPanel.SetActive(true);
        //SceneManager.LoadScene(0);
    }
}
