using System;
using UnityEngine;

public class DailyBonus : MonoBehaviour
{
    public GameObject monday;
    public GameObject tuesday;
    public GameObject wednesday;
    public GameObject thursday;
    public GameObject friday;
    
    public GameObject winButton;

    void Start()
    {
        DateTime dateTime = DateTime.Now;
        if (dateTime.DayOfWeek.ToString() == "Monday")
        {
            monday.SetActive(true);
            SetButtonEnable();
        }

        if (dateTime.DayOfWeek.ToString() == "Tuesday")
        {
            tuesday.SetActive(true);
            SetButtonEnable();
        }

        if (dateTime.DayOfWeek.ToString() == "Wednesday")
        {
            wednesday.SetActive(true);
            SetButtonEnable();
        }

        if (dateTime.DayOfWeek.ToString() == "Thursday")
        {
            thursday.SetActive(true);
            SetButtonEnable();
        }

        if (dateTime.DayOfWeek.ToString() == "Friday")
        {
            friday.SetActive(true);
            SetButtonEnable();
        }

        if (dateTime.DayOfWeek.ToString() == "Saturday" || dateTime.DayOfWeek.ToString() == "Sunday")
        {
            monday.SetActive(false);
            tuesday.SetActive(false);
            wednesday.SetActive(false);
            thursday.SetActive(false);
            friday.SetActive(false);
            winButton.SetActive(false);
        }
    }

    private void SetButtonEnable()
    {
        winButton.SetActive(true);
    }
}
