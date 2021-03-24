using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Windows.Speech;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GrammerController : MonoBehaviour
{
    private string _Keyresponse = "";
    private string _response = "";
    private PauseMenu pauseMenu;
    private SetVolume setVolume; 
    private Player player;
    public Text results;
    // SRSG Speech Recogition Specification Grammer XML grammer
    private GrammarRecognizer gr;
    Scene sceneO;
    private void Start() {
       gr = new GrammarRecognizer(Path.Combine(Application.streamingAssetsPath,  
         "MainMenu.xml"), ConfidenceLevel.Low); 

        //gr = new GrammarRecognizer(Application.streamingAssetsPath + 
        //"/SimpleGrammer.xml", ConfidenceLevel.Medium);
        gr.OnPhraseRecognized += GR_OnPhraseRecognized;
        gr.Start();
        //Debug.Log("Grammer Load and Recogniser Started!");
        results.text = _response;
        pauseMenu = FindObjectOfType<PauseMenu>();
        setVolume = FindObjectOfType<SetVolume>();
        player = FindObjectOfType<Player>();
        sceneO = SceneManager.GetActiveScene();
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Active Scene is '" + scene.name + "'.");
    }
    private void Update() {
        //Switch between the Words Spoken
        //Debug.Log("Look");
        if(_Keyresponse == "pause" && !PauseMenu.IsPaused){
            switch (_response)
            {
                case "pause the game":
                    pauseMenu.Pause();
                    break;
            }
            results.text = "Game Paused " + _response;
            _response = "";
        }
        if(_Keyresponse == "pause" && PauseMenu.IsPaused){
            switch (_response)
            {
                case "continue":
                    pauseMenu.Resume();
                    break;
                case "restart":
                    pauseMenu.RestartLevel();
                    break;
                case "quit":
                    pauseMenu.QuitToMainMenu();
                    break;
                case "back":
                    pauseMenu.BackToMenu();   
                    break;
                case "decrease":
                    setVolume.DecreaseVolume(0.1f);   
                    break;
                case "increase":
                    setVolume.IncreaseVolume(0.1f);   
                    break;
                default:
                    _response = "";
                    break;
            }
            results.text = "In Pause Menu " + _response;
            _response = "";
        }
        if(_Keyresponse == "volume" && PauseMenu.IsPaused){
            switch (_response)
            {
                case "decrease":
                    setVolume.DecreaseVolume(0.1f);   
                    break;
                case "increase":
                    setVolume.IncreaseVolume(0.1f);   
                    break;
                default:
                    _response = "";
                    break;
            }
            results.text = "In Volume " + _response;
            _response = "";
        }
        
        if(_Keyresponse == "movement" && !PauseMenu.IsPaused){
            
            switch (_response)
            {
                case "up":
                    player.UpSpeech();
                    break;
                case "fire":
                    player.AtackSpeech();
                    break;
                case "stop fire":
                    player.StopAtackSpeech();
                    break;
                case "down":
                    player.DownSpeech();
                    break;
                default:
                    _response = "";
                    break;
            }
            results.text = "In Movement " + _response;
            _response = "";
        }
        if(_Keyresponse == "menu" && sceneO.buildIndex == 0){
            switch (_response)
            {
                case "start":
                    SceneLoader(1);
                    break;
                case "exit":
                    QuitGame();
                    break;
                default:
                    _response = "";
                    break;
            }
            results.text = "In Menu " + _response;
            _response = "";
        }
         
    }
    

    private void GR_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        //Debug.Log("In Gr");
        StringBuilder message = new StringBuilder();
        //Read the semantic meanings from the args passed in
        SemanticMeaning[] meanings = args.semanticMeanings;
        
        //use foreach to get all the meanings.
        foreach (SemanticMeaning meaning in meanings)
        {
            string keyString = meaning.key.Trim();
            var valueString = meaning.values[0].Trim();

            message.Append("Key " + keyString + "Value " + valueString + " ");

            _response = valueString;
            _Keyresponse = keyString;
            //Debug.Log("This is the Key " + keyString);
            
            
        }
        
        //use a string builder to create the string and out to the user.
        Debug.Log(message);
    }
    private void OnApplicationQuit()
    {
        if (gr == null || !gr.IsRunning) return;
        gr.OnPhraseRecognized -= GR_OnPhraseRecognized;
        gr.Stop();
    }
    private void OnDestroy()
    {
        if (gr != null)
        {
            gr.Stop();
            gr.OnPhraseRecognized -= GR_OnPhraseRecognized;
            gr.Dispose();
            gr = null; 
        }
    }

    public void SceneLoader(int level){
        SceneManager.LoadScene(level);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }


}
