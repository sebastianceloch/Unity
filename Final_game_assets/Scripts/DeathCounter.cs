using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeathCounter : MonoBehaviour
{
    public static DeathCounter instance;

    public TMP_Text deathText;
    public int curDeaths = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        deathText.text = "DEATHS: " + curDeaths.ToString();
    }

    public void AddDeaths(int value)
    {
        curDeaths += value;
        deathText.text = "DEATHS: " + curDeaths.ToString();
    }
}
