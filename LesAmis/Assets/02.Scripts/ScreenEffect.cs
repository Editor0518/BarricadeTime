using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScreenEffect : MonoBehaviour
{
    public Animator[] anim;

    public void LongBlackFade(int index) {
        anim[index].SetTrigger("LongBlackFade");
    }

    public void BloodEffect(int index, bool isOn) {
        anim[index].SetBool("BloodEffect", isOn);
    }






}
