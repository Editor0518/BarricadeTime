using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControlCard : MonoBehaviour
{
    public Transform cardTrans;
    public ContentManager cm;

    [Header("Choice")]
    public Image blackback;
    public TMP_Text choiceATxt;
    public TMP_Text choiceBTxt;

    //float width = 1920f;
    float width2, width10;
    float maxRot = 13f;

    [Range(-1,1)]
    public int currentChoice =0;
    bool canMove = false;

    [Header("Variable Circles")]
    public Image passionSmallCircle;
    public Image passionBigCircle;

    public Image peopleSmallCircle;
    public Image peopleBigCircle;

    public Image gunSmallCircle;
    public Image gunBigCircle;

    public Image moneySmallCircle;
    public Image moneyBigCircle;


    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip audioClip;

    //int smallMax = 10;
    int bigMin = 20;


    float dftY;
    private void Start()
    {
        dftY = cardTrans.localPosition.y;
    }


    void Update() {
        //width = Screen.width;
        width2 = 610 / 2;//width / 2;
        width10 = 100;//width / 10;

        if (!canMove) {
            cardTrans.localPosition = new Vector3(0, dftY, cardTrans.localPosition.z);
            cardTrans.eulerAngles = new Vector3(0, 0, 0);
            HideChoice();
            return;
        }

        float rotZ;
        float posX;
        float posY;
        rotZ = (width2 - Input.mousePosition.x) / 8;
        if (rotZ > maxRot) rotZ = maxRot;
        if (rotZ < -maxRot) rotZ = -maxRot;

        if (Input.mousePosition.x < width2 - width10) {
            ShowChoiceB();
            posX = -width10 * 0.0175f;//width2 - width10;//width10
            posY = 0.2f;
            if (currentChoice != 1) audioSource.PlayOneShot(audioClip);
            currentChoice = 1;
        }
        else if (Input.mousePosition.x > width2 + width10) {
            ShowChoiceA();
            posX = width10* 0.0175f;//width2 + width10;
            posY = 0.2f;
            if (currentChoice != -1) audioSource.PlayOneShot(audioClip);
            currentChoice = -1;
        }
        else {
            /*if (Input.mousePosition.x < width2 - (width10 / 4)) { 
                ShowChoiceA(); 
            }
            else if (Input.mousePosition.x > width2 + (width10 / 4)) { 
                ShowChoiceB();
            }
            else { */
                HideChoice();

            //}
            posX = ((Input.mousePosition.x / width2)-1f) * 5;// * 0.005f;
            posY = (Input.mousePosition.x) * 0.0006f;
            
        }

        cardTrans.localPosition = new Vector3(posX, posY, cardTrans.localPosition.z);
        cardTrans.eulerAngles = new Vector3(0, 0, rotZ);

    }

    //Card 게임오브젝트의 Event Trigger에서 사용함.
    public void PickUpDown() {
        canMove = true;//!canMove;
    }
    public void CanMoveFalse() { canMove = false; }


    void ShowChoiceB() {
        ShowChoice(true, true); 
        if (cm.prefab != null) ManageVarCircle(cm.prefab.passionB, cm.prefab.peopleB, cm.prefab.gunB, cm.prefab.moneyB);
    }

    void ShowChoiceA() {
        ShowChoice(true, false);
        if(cm.prefab != null) ManageVarCircle(cm.prefab.passionA, cm.prefab.peopleA, cm.prefab.gunA, cm.prefab.moneyA);
    }

    void ShowChoice(bool isOn, bool isA) {
        blackback.enabled = isOn;
        choiceATxt.enabled = isOn && isA;
        choiceBTxt.enabled = isOn && !isA;
    }

    void HideChoice() {
        ShowChoice(false, false);
        currentChoice = 0;
        ManageVarCircle(0, 0, 0, 0);
    }


    void ManageVarCircle(int passion, int people, int gun, int money) {
        passion = Math.Abs(passion);
        people = Math.Abs(people);
        gun = Math.Abs(gun);
        money = Math.Abs(money);// 20 <= 10 
        passionBigCircle.enabled = bigMin <= passion && passion > 0;
        passionSmallCircle.enabled = bigMin > passion && passion > 0;

        peopleBigCircle.enabled = bigMin <= people && people > 0;
        peopleSmallCircle.enabled = bigMin > people && people > 0;

        gunBigCircle.enabled = bigMin <= gun && gun > 0;
        gunSmallCircle.enabled = bigMin > gun && gun > 0;

        moneyBigCircle.enabled = bigMin <= money && money > 0;
        moneySmallCircle.enabled = bigMin > money && money > 0;

        /*if (passion > 15 || passion > 0) { passionBigCircle.enabled = true; }
        else if (passion > 5 || passion < 0) { }
        else { }*/
    }

}
