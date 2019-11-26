using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButton : UIScript
{
    private bool musicMuted; //True is muziek is gemute
    private AudioSource music;

    private void Awake()
    {
        GetComponentInChildren<Button>().onClick.AddListener(MuteKnopClicked);
        clickableButton = GetComponentInChildren<Button>();
        mainCamera = FindObjectOfType<Camera>();
        music = mainCamera.GetComponent<AudioSource>();
        clickableButton.transform.position = new Vector3(mainCamera.transform.position.x - 10f, mainCamera.transform.position.y - 4f, mainCamera.transform.position.z + 10);
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
                music.mute = false;
                break;
            case false:
                musicMuted = true;
                music.mute = true;
                break;
        }
    }
}
