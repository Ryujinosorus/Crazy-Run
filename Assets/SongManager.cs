using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongManager : MonoBehaviour
{
    [SerializeField] Sprite imageOn,imageOff;
    private void Start()
    {
        if(PlayerPrefs.GetFloat("crazy_vol",1)==0)
            GetComponent<Image>().sprite = imageOff;
        else GetComponent<Image>().sprite = imageOn;
        GameObject.Find("chefDeProjet").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("crazy_vol", 1);
    }
    public void clickOnSprite()
    {
        if(GetComponent<Image>().sprite == imageOn)
        {
            GetComponent<Image>().sprite = imageOff;
            GameObject.Find("chefDeProjet").GetComponent<AudioSource>().volume = 0;
            PlayerPrefs.SetFloat("crazy_vol", 0);
            return;
        }
        GetComponent<Image>().sprite = imageOn;
        GameObject.Find("chefDeProjet").GetComponent<AudioSource>().volume = 1;
        PlayerPrefs.SetFloat("crazy_vol", 1);
    }
}
