using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveUI : MonoBehaviour
{
    public Waves wave;
    private Text waveText;

    private void Start()
    {
        wave = FindObjectOfType<Waves>();
        waveText = GetComponent<Text>();
    }

    private void Update()
    {
        waveText.text = "" + wave.waveNumber;
    }
}
