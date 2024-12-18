using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider musicSlider, sfxSlider;
    [SerializeField] Sprite musicOnSprite;
    [SerializeField] Sprite musicOffSprite;
    private bool isMusicOn = true;
    private bool isSFXOn = true;
    public Button toggleMusicButton;
    public Button toggleSFXButton;


    public void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic();
        isMusicOn = !isMusicOn;
        UpdateMusicButtonSprite();
        AudioManager.Instance.PlaySFX("DefaultClick");
    }
    public void ToggleSFX()
    {
        AudioManager.Instance.ToggleSFX();
        isSFXOn= !isSFXOn;
        UpdateSFXButtonSprite();
        AudioManager.Instance.PlaySFX("DefaultClick");
    }

    public void MusicVolume()
    {
        AudioManager.Instance.MusicVolume(musicSlider.value);
        
    }

    public void SFXVolume()
    {
        AudioManager.Instance.SFXVolume(sfxSlider.value);
        
    }

    private void UpdateMusicButtonSprite()
    {
        if (isMusicOn)
        {
            toggleMusicButton.image.sprite = musicOnSprite; // Set "Music On" icon
        }
        else
        {
            toggleMusicButton.image.sprite = musicOffSprite; // Set "Music Off" icon
        }
    }

    private void UpdateSFXButtonSprite()
    {
        if (isSFXOn)
        {
            toggleSFXButton.image.sprite = musicOnSprite; // Set "Music On" icon
        }
        else
        {
            toggleSFXButton.image.sprite = musicOffSprite; // Set "Music Off" icon
        }
    }
}
