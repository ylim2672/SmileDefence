using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnOff : MonoBehaviour
{
    public GameObject Panel;
    public AudioSource audioSource;
    public Sprite MusicOn;
    public Sprite MusicOff;
    public Button Music;

    public void OnOffPanel()
    {
        if (Panel.activeSelf)
        {
            Debug.Log("click");
            Panel.SetActive(false);
        }
        else
            Panel.SetActive(true);
    }

    public void OnOffMusic()
    {
        if (audioSource.isPlaying)
        {
            Music.image.sprite = MusicOff;
            audioSource.Pause();
        }

        else
        {
            Music.image.sprite = MusicOn;
            audioSource.Play();
        }
    }

}
