using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
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

    void Start()
    {
        // if (PlayerPrefs.GetInt("Restart", 0)!=0)
        //     _onRestart.Invoke();
    }

    
    public void StartLevel()
    {
        Debug.Log("start");
        _onStartGame.Invoke();
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Menu Game");
    }
    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void PauseGame ()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame ()
    {
        Time.timeScale = 1;
    }
    
    public void AddBall()
    {
        ballsNumber++;
        _endGameScore += 5;
        _scoreTxt.text="Score:\n"+_endGameScore;
        
    }

    public void RemoveBall()
    {
        
        ballsNumber--;
        if (ballsNumber <= 0 && !gameOver)
        {
            Debug.Log("Next Level");
            _endGameScore += (int)(3 * TimerGame.GetTime());
            PlayerPrefs.SetInt("Score",_endGameScore);
            PlayerPrefs.Save();
            _FinalScoreTxt.text = "your score with bonus time: " + _endGameScore;
            PauseGame();
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
            
            _timer.SetTimeFloat(_startGameDelay);
        } 
    }
    
    
    
    
   
}
