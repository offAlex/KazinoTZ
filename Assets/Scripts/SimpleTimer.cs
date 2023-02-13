using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SimpleTimer: MonoBehaviour
{
    [SerializeField] public  float time;
    [SerializeField] private TextMeshProUGUI timerText;
 
    private float _timeLeft = 0f;
    private bool _timerOn = false;
 
    private void Start()
    {
        _timeLeft = time;
        _timerOn = true;
    }
 
    private void Update()
    {
        if (_timerOn)
        {
            if (_timeLeft > 0)
            {
                _timeLeft -= Time.deltaTime;
                UpdateTimeText();
            } else
            {
                _timeLeft = time;
                _timerOn = false;
            }

            if (SceneController._score >= 10)
            {
                _timeLeft = time;
                _timerOn = false;
            }
        }
    }
 
    private void UpdateTimeText()
    {
        if (_timeLeft < 0)
            _timeLeft = 0;
 
        float minutes = Mathf.FloorToInt(_timeLeft / 60);
        float seconds = Mathf.FloorToInt(_timeLeft % 60);
        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}