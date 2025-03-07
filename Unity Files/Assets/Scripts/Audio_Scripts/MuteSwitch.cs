﻿using UnityEngine;
using UnityEngine.UI;

public class MuteSwitch : MonoBehaviour {

    [SerializeField]
    private Image imgFXSound, imgMusic;

    [SerializeField]
    private Sprite[] sprFX, sprMusic;

    //Public static
    public static bool isFXMuted = false, isMusicMute = false;

    private void OnEnable()
    {
        Initialize();
    }

    private void Initialize()
    {
        isFXMuted = DevolverBoolMemoria("fxMuted");
        isMusicMute = DevolverBoolMemoria("musicMuted");

        SpriteSwap();
        TurnDownMusicVolume();
    }

    void SetNewBoolValue(string id, bool valor) 
    {
        if (!valor)
            PlayerPrefs.SetInt(id, 0);
        else
            PlayerPrefs.SetInt(id, 1);
    }

    bool DevolverBoolMemoria(string id)
    {
        if (PlayerPrefs.GetInt(id) == 0)
            return false;
        else
            return true;
    }

    void TurnDownMusicVolume()
    {
        try
        {
            GameObject music = GameObject.FindGameObjectWithTag("music");
            AudioSource musica = music.GetComponent<AudioSource>();

            if (isMusicMute)
                musica.volume = 0;
            else
                musica.volume = 0.65f;
        }
        catch { Debug.Log("Soundtrack nao encontrada!"); }
    }

    void SpriteSwap()
    {
        if (isFXMuted)
            imgFXSound.sprite = sprFX[1];
        else
            imgFXSound.sprite = sprFX[0];

        if (isMusicMute)
            imgMusic.sprite = sprMusic[1];
        else
            imgMusic.sprite = sprMusic[0];
    }
    public void MuteFX()
    {
        isFXMuted = !isFXMuted;

        SetNewBoolValue("fxMuted", isFXMuted);

        SpriteSwap();
    }

    public void MuteMusic()
    {
        isMusicMute = !isMusicMute;

        SetNewBoolValue("musicMuted", isMusicMute);

        SpriteSwap();

        TurnDownMusicVolume();
    }
}
