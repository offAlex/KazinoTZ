using System;
using System.Collections;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;


public class RotateBaraban : MonoBehaviour
{
    public GameObject baraban;
    private float _speed = 5f;
    private float _maxSpeed;
    private bool _boolAwards;
    private string _awards;

    public TextMeshProUGUI text;

    private void Start()
    {
        _boolAwards = false;
    }

    public void FixedUpdate()
    {
        if (_maxSpeed > 0)
        {
            _maxSpeed -= _speed * 20f * Time.deltaTime;
            baraban.transform.Rotate(0, 0, _maxSpeed * Time.deltaTime);
            Debug.Log(_maxSpeed);
        }

        if (_boolAwards && _maxSpeed < 0)
        {
            _boolAwards = false;
            TakeAwards();
            text.text = "Your Win: " + _awards;
        }

    }

    private void TakeAwards()
    {
        if (baraban.transform.eulerAngles.z >= 0 && baraban.transform.eulerAngles.z <= 47)
        {
            _awards = "Orange";
        }
        if (baraban.transform.eulerAngles.z > 47 && baraban.transform.eulerAngles.z <= 92)
        {
            _awards = "Green";
        }
        if (baraban.transform.eulerAngles.z > 92 && baraban.transform.eulerAngles.z <= 138)
        {
            _awards = "Red";
        }
        if (baraban.transform.eulerAngles.z > 138 && baraban.transform.eulerAngles.z <= 182)
        {
            _awards = "Black";
        }
        if (baraban.transform.eulerAngles.z > 182 && baraban.transform.eulerAngles.z <= 228)
        {
            _awards = "Yellow";
        }
        if (baraban.transform.eulerAngles.z > 228 && baraban.transform.eulerAngles.z <= 272)
        {
            _awards = "Blue";
        }
        if (baraban.transform.eulerAngles.z > 272 && baraban.transform.eulerAngles.z <= 313)
        {
            _awards = "Purple";
        }
        if (baraban.transform.eulerAngles.z >319 && baraban.transform.eulerAngles.z <360)
        {
            _awards = "light blue";
        }

    }

    public void StartRotateBaraban()
    {
        _boolAwards = true;
        _maxSpeed = Random.Range(300f, 500f);
    }
}
