using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource bgmPlayer;
    public AudioSource sfxPlayer;
    // Reference the background musics
    public AudioClip[] backgroundMusics;
    // Reference the sound effects
    public AudioClip[] soundEffects;

    // Play main menu music function
    public void PlayMainMenuMusic()
    {
        // Assert that the background musics array is not empty
        Debug.Assert(backgroundMusics.Length > 0, "Background musics array is empty!");
        // Assert that the background musics array has enough musics
        Debug.Assert(backgroundMusics.Length >= 1, "Background musics array does not have enough musics!");
        // Play the main menu music
        bgmPlayer.clip = backgroundMusics[0];
        bgmPlayer.Play();
    }

    // Play in-game music function
    public void PlayInGameMusic()
    {
        // Assert that the background musics array is not empty
        Debug.Assert(backgroundMusics.Length > 0, "Background musics array is empty!");
        // Assert that the background musics array has enough musics
        Debug.Assert(backgroundMusics.Length >= 2, "Background musics array does not have enough musics!");
        // Play the in-game music
        bgmPlayer.clip = backgroundMusics[1];
        bgmPlayer.Play();
    }

    // Play food sfx function
    public void PlayFoodSFX()
    {
        // Assert that the sound effects array is not empty
        Debug.Assert(soundEffects.Length > 0, "Sound effects array is empty!");
        // Assert that the sound effects array has enough sound effects
        Debug.Assert(soundEffects.Length >= 1, "Sound effects array does not have enough sound effects!");
        // Play the food sfx
        sfxPlayer.clip = soundEffects[0];
        sfxPlayer.Play();
    }

    // Play water sfx function
    public void PlayWaterSFX()
    {
        // Assert that the sound effects array is not empty
        Debug.Assert(soundEffects.Length > 0, "Sound effects array is empty!");
        // Assert that the sound effects array has enough sound effects
        Debug.Assert(soundEffects.Length >= 2, "Sound effects array does not have enough sound effects!");
        // Play the water sfx
        sfxPlayer.clip = soundEffects[1];
        sfxPlayer.Play();
    }

    // Play honeydew sfx function
    public void PlayHoneydewSFX()
    {
        // Assert that the sound effects array is not empty
        Debug.Assert(soundEffects.Length > 0, "Sound effects array is empty!");
        // Assert that the sound effects array has enough sound effects
        Debug.Assert(soundEffects.Length >= 3, "Sound effects array does not have enough sound effects!");
        // Play the honeydew sfx
        sfxPlayer.clip = soundEffects[2];
        sfxPlayer.Play();
    }

    // Play building materials sfx function
    public void PlayBuildingMaterialsSFX()
    {
        // Assert that the sound effects array is not empty
        Debug.Assert(soundEffects.Length > 0, "Sound effects array is empty!");
        // Assert that the sound effects array has enough sound effects
        Debug.Assert(soundEffects.Length >= 4, "Sound effects array does not have enough sound effects!");
        // Play the building materials sfx
        sfxPlayer.clip = soundEffects[3];
        sfxPlayer.Play();
    }

    // Play win sfx function
    public void PlayWinSFX()
    {
        // Assert that the sound effects array is not empty
        Debug.Assert(soundEffects.Length > 0, "Sound effects array is empty!");
        // Assert that the sound effects array has enough sound effects
        Debug.Assert(soundEffects.Length >= 5, "Sound effects array does not have enough sound effects!");
        // Play the win sfx
        sfxPlayer.clip = soundEffects[4];
        sfxPlayer.Play();
    }

    // Play lose sfx function
    public void PlayLoseSFX()
    {
        // Assert that the sound effects array is not empty
        Debug.Assert(soundEffects.Length > 0, "Sound effects array is empty!");
        // Assert that the sound effects array has enough sound effects
        Debug.Assert(soundEffects.Length >= 6, "Sound effects array does not have enough sound effects!");
        // Play the lose sfx
        sfxPlayer.clip = soundEffects[5];
        sfxPlayer.Play();
    }

    // Play hopper jump sfx function
    public void PlayHopperJumpSFX()
    {
        // Assert that the sound effects array is not empty
        Debug.Assert(soundEffects.Length > 0, "Sound effects array is empty!");
        // Assert that the sound effects array has enough sound effects
        Debug.Assert(soundEffects.Length >= 7, "Sound effects array does not have enough sound effects!");
        // Play the hopper jump sfx
        sfxPlayer.clip = soundEffects[6];
        sfxPlayer.Play();
    }
}
