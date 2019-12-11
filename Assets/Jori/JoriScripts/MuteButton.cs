using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButton : UIScript
{
    private bool musicMuted; //True is muziek is gedempt
    private AudioSource music;

    private void Awake()
    {
        AddListener(MuteKnopClicked);
   
        musicMuted = false;
        buttonText = clickableButton.GetComponentInChildren<Text>();
        buttonText.text = "";
    }

    private void MuteKnopClicked()
    {
        switch (musicMuted)
        {
            case true:
                musicMuted = false;
                AudioListener.pause = true;
                AudioListener.volume = 0;
                break;
            case false:
                musicMuted = true;
                AudioListener.pause = false;
                AudioListener.volume = 1;
                break;
        }
    }
}
