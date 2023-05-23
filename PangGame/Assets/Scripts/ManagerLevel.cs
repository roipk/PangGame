
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManagerLevel : MonoBehaviour
{
    public static ManagerLevel instance;
    [SerializeField] private TextUi _timer;
    [SerializeField] private Text _scoreTxt;
    [SerializeField] private Text _FinalScoreTxt;
    [SerializeField] private GameObject _ball;
    [SerializeField] private int ballsNumber = 0;
    [SerializeField] private float _startGameDelay = 5;
    [SerializeField] private int _endGameScore;
    [SerializeField] private bool _isMenu;
    
    [Space] [SerializeField] private UnityEvent _onStartGame;
    [SerializeField] private UnityEvent _onGameOver;
    [SerializeField] private UnityEvent _onEndLevel;
    [SerializeField] private UnityEvent _onRestart;

    private bool enableGame;
    public bool gameOver;
    
    // Start is called before the first frame update

    private void Awake()
    {
        if(instance)
            Destroy(gameObject);

        instance = this;
        ResumeGame();
        _endGameScore = PlayerPrefs.GetInt("Score", 0);
    }


    public void StartLevel()
    {
        // Invokes the event to signal the start of the game
        _onStartGame.Invoke();
        
    }

    public void RestartGame()
    {
        // Restarts the game by loading the "Menu Game" scene
        SceneManager.LoadScene("Menu Game");
    }
    public void LoadSceneByName(string sceneName)
    {
        // Loads a scene by its name
        SceneManager.LoadScene(sceneName);
    }

    public void PauseGame ()
    {
        // Pauses the game by setting the timescale to 0
        Time.timeScale = 0;
    }
    public void ResumeGame ()
    {
        // Resumes the game by setting the timescale back to 1
        Time.timeScale = 1;
    }
    
    public void AddBall()
    {
        // Increases the ballsNumber and updates the score
        ballsNumber++;
        _endGameScore += 5;
        _scoreTxt.text="Score:\n"+_endGameScore;
        
    }

    public void RemoveBall()
    {
        // Decreases the ballsNumber and checks if all balls are gone
        ballsNumber--;
        if (ballsNumber <= 0 && !gameOver)
        {
            // Calculates the final score with a time bonus and displays it
            _endGameScore += (int)(3 * TimerGame.GetTime());
            PlayerPrefs.SetInt("Score",_endGameScore);
            PlayerPrefs.Save();
            _FinalScoreTxt.text = "your score with bonus time: " + _endGameScore;
            PauseGame();
            // Invokes the event to signal the end of the level
            _onEndLevel.Invoke();
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (_startGameDelay > 0 && !_isMenu)
        {
            _startGameDelay -= Time.deltaTime;
            if (_startGameDelay < 0)
            {
                _startGameDelay = 0;
                StartLevel();
            }
            
            // Updates the timer UI with the remaining start game delay time
            _timer.SetTimeFloat(_startGameDelay);
        } 
    }
    
    
    
    
   
}
