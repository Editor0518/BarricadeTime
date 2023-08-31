using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceWhenSelect : MonoBehaviour
{
    [Header("[Button]")]
    Button button;
    RectTransform trans;
    Outline outline;
    public Image check;
    public AudioClip audioClip;
    public AudioSource audiosource;
    Vector2 size;

    [Header("Variable")]
    public Image passion_big;
    public Image passion_small;
    public Image people_big;
    public Image people_small;
    public Image gun_big;
    public Image gun_small;
    public Image money_big;
    public Image money_small;



    void Start()
    {
        GetComponent();
    }

    public void SelectOn() {
        if (!button.interactable) return;
        trans.sizeDelta = size * 1.05f;
        outline.enabled = true;
        check.enabled = true;
        if(audioClip!=null&&audiosource!=null) audiosource.PlayOneShot(audioClip);
    }

    public void SelectOff() {
        trans.sizeDelta = size;
        outline.enabled = false;
        check.enabled = false;
    }

    public void ResetBtn() {
        GetComponent();
        SelectOff();
        Input.ResetInputAxes();
        button.interactable = true;

    }

    void GetComponent() {
        if(trans==null) trans = GetComponent<RectTransform>();
        if (outline == null) outline = GetComponent<Outline>();
        if (button == null) button = GetComponent<Button>();
        size = new Vector2(805, 120);//trans.sizeDelta;
        Debug.Log(size);
    }

}
