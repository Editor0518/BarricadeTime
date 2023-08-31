using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ContentManager : MonoBehaviour
{
    [Header("[Top Bar]")]
    public TMP_Text loopEnjTxt;
    public TMP_Text leftDayTxt;
    public TMP_Text dateTxt;

    //[Header("[Variables]")]
    //public VariableManager vm;
/*  public Image passionImg;
    public Image peopleImg;
    public Image gunImg;
    public Image moneyImg;*/

    [Header("[Content]")]
    public TMP_Text nameTxt;
    public TMP_Text explainTxt;
    public GameObject spineObj;
    public Image cardImg;
    public Image cardIllust;
    public Transform cardCanvas;

    //public Image nameImg;
    public TMP_Text contentTxt;
    [Header("[Choice A]")]
    public TMP_Text choiceATxt;
    //public ChoiceWhenSelect choiceA;
    [Header("[Choice B]")]
    public TMP_Text choiceBTxt;
    //public ChoiceWhenSelect choiceB;

    [Header("Card")]
    public ControlCard cc;
    public VariableManager vm;
    public DeathManager dm;
    public ContainVariable cv;
    public StackList stack;
    public SayingScript prefab;
    public CollectionManager cm;

    [Header("Audio")]
    public AudioSource audioBGM;
    public AudioSource audioSE;
    public AudioSource audioVCE;
    public AudioClip CardChageClip;

    public GameObject tempObj;


    [Header("ȭ�� ����Ʈ")]
    public ScreenEffect screenEffect;
    public GameObject panel;


    [Header("�ӽ� ����")]
    public Image spriteRender;
    public Sprite temp_Enj;
    public Sprite temp_R;
    public Sprite temp_Comb;
    public Sprite temp_Courf;
    public Sprite temp_Boss;
    public Sprite temp_Baho;
    public Sprite temp_Feui;
    public Sprite temp_Jehan;
    public Sprite temp_Joly;
    public Sprite temp_Mari;
    public Sprite temp_Then;
    

    /// <summary> dateSort: ��¥ ǥ�� ���. ������ �Ⱦ�. �⺻��=0.
    /// 0 = YYYY/MM/DD --> 1832�� 6�� 6��
    /// 1 = MM/DD/YYYY(�̱���) June 6, 1832
    /// 2 = DD/MM/YYYY(������) 6th June 1832
    /// 1st, 2nd, 3rd, 21st, 22nd, 23rd, 31st / �������� ��� th
    /// </summary>
    public int dateSort = 0;

    void Start() {
        stack = transform.GetChild(0).GetComponent<StackList>();
        CalculateLeftDays(1830, 7, 27);//���� 678�� 680�����ϴµ�
        //CalculateLeftDays(1831, 1, 1);
        stack.LoadAll();
        GetRandomFromList();
        //GetSayingScriptFromPrefab();
    }

    //public SayingScript sc;


    public void GetRandomFromList() {
        //if (stack.stackList.Count == 0) stack.LoadAll();
        if (stack.stackList.Count == 0) return;

        vm.CheckIfDead();


        if (stack.stackTimeList.Count > 0) {
            if (stack.stackTimeList[0].leftDays == 0) {
                prefab = stack.stackTimeList[0].stack.GetComponent<SayingScript>();
                stack.stackTimeList.RemoveAt(0);
               // Debug.Log(stack.stackTimeList[0].leftDays);
            }


            for (int i = 0; i < stack.stackTimeList.Count; i++) {
                stack.stackTimeList[i] = stack.StackWithTimeMaker(stack.stackTimeList[i].stack, stack.stackTimeList[i].leftDays - 1);
            }

        }/*
        else if (stack.stackDateList.Count > 0) {
        }*/
        else if (stack.stackDeathList.Count > 0)
        {
            Debug.Log(stack.stackDeathList[0]);
            prefab = stack.stackDeathList[0].GetComponent<SayingScript>();
        }
        else {



            int random = Random.Range(0, stack.stackList.Count);
            prefab = stack.stackList[random].GetComponent<SayingScript>();

            stack.stackList.RemoveAt(random);


        }
        
        GetSayingScriptFromPrefab();

        audioSE.PlayOneShot(CardChageClip);
    }

    public void GetSayingScriptFromPrefab() {
        //choiceA.ResetBtn();
        //choiceB.ResetBtn();
        if (prefab == null) {//��������
            contentTxt.text = "";
            //choiceA.gameObject.SetActive(false);
            //choiceB.gameObject.SetActive(false);
            GetRandomFromList();
        }

        cardCanvas.gameObject.SetActive(false);
        cardCanvas.gameObject.SetActive(true);
        if(cv.numOfLoop>0) loopEnjTxt.text = cv.numOfLoop + " ȸ��";
        else loopEnjTxt.text = "";
        //if (prefab.transform.GetComponent<SayingScript>()) {
        //sc = prefab.transform.GetComponent<SayingScript>();
        //ChangeContent(sc.c_name, sc.content, sc.choiceA, sc.choiceB);
        ChangeContent(prefab.c_name, prefab.content, prefab.choiceA, prefab.choiceB);
        // ChangeIllust(sc.c_cmd);
        ChangeIllust(prefab.c_cmd);
        PlaySounds(prefab.bgmToChange, prefab.seToPlay, prefab.vceToPlay);

        if (prefab.dateToSet != "") {//if (sc.dateToSet != "") {
                                     //string[] str = sc.dateToSet.Split(".");

            if (prefab.dateToSet.Contains(".")) { 
            string[] str = prefab.dateToSet.Split(".");
            /*int[] iDate=new int[str.Length];

            for (int i = 0; i < iDate.Length; i++) {
                iDate[i] = int.Parse(str[i]);
            }

            SetDateAndDay(iDate[0], iDate[1], iDate[2]);*/
            SetDateAndDay(str[0], str[1], str[2]);
            }
        }

        /*}
        else {//��������
            prefab = null;
            contentTxt.text = "";
            //choiceA.gameObject.SetActive(false);
            //choiceB.gameObject.SetActive(false);
            Debug.Log("����");
        }*/

    }

    public void PlaySounds(AudioClip bgm, AudioClip se, AudioClip voice) {
        if (bgm != null) {
            audioBGM.Stop();
            audioBGM.clip = bgm;
            audioBGM.Play();
        }
        if (se != null) {
            audioSE.Stop();
            audioSE.clip = se;
            audioSE.Play();
        }
        if (voice != null) {
            audioVCE.Stop();
            audioVCE.clip = voice;
            audioVCE.Play();
        }
    }


    //Card ���ӿ�����Ʈ�� Event Trigger���� �����.
    public void CheckChoiceAndChange() {
        if (cc.currentChoice < 0) {

            ChangePrefabToA();

        }
        else if (cc.currentChoice > 0) {
            ChangePrefabToB();

        }
        cc.currentChoice = 0;
        cc.CanMoveFalse();
    }


    void UpdateVariable(int passionAdd, int peopleAdd, int gunAdd, int moneyAdd) {
        vm.ChangeVariable(passionAdd, peopleAdd, gunAdd, moneyAdd);
    }

    void EtcSetting(string etc) {
        
        string[] cmd = etc.Split(", ");

        for (int i = 0; i < cmd.Length; i++) {
            if (cmd[i].Contains("&")) {
                string strCmd = cmd[i];
                strCmd = strCmd.Substring(1);

                string[] str = strCmd.Split("_");

                Animator anim = GameObject.FindGameObjectWithTag(str[0]).GetComponent<Animator>();
                if (anim != null) anim.SetTrigger(str[1]);

            }
            cmd[i] = cmd[i].ToLower();


            if (cmd[i].Contains("get_story")) {
                
            }

            if (cmd[i].Contains("get_death"))
            {
                string[] data = cmd[i].Split(".");
                cm.SaveDeathCol(data[1], cv.numOfLoop);
            }
            if (cmd[i].Contains("get_memory"))
            {
                string[] data = cmd[i].Split(".");
                cm.SaveMemoryCol(data[1], cv.numOfLoop);
            }

            if (cmd[i].Equals("anim_longblackfade"))
            {
                screenEffect.LongBlackFade(i);
            }
            else if (cmd[i].Equals("anim_bloodon"))
            {
                screenEffect.BloodEffect(i, true);
            }
            else if (cmd[i].Equals("anim_bloodoff"))
            {
                screenEffect.BloodEffect(i, false);
            }
            else if (cmd[i].Equals("reset"))
            {
                cv.LoopTimesPlusOne();
                stack.ResetAll();
                stack.LoadAll();
                vm.ClearVariable();
                panel.SetActive(true);

            }
            else if (cmd[i].Contains("newcard_")) {
                string[] str = cmd[i].Split("_");
                stack.AddNewCards(str[1]);
            }


        }

    }





    public void ChangePrefabToA() {
        if (prefab == null) return;


        //if (sc == null) sc = prefab.GetComponent<SayingScript>();
        //UpdateVariable(sc.passionA, sc.peopleA, sc.gunA, sc.moneyA);
        UpdateVariable(prefab.passionA, prefab.peopleA, prefab.gunA, prefab.moneyA);
        EtcSetting(prefab.etcA);

        if (prefab.transform.childCount > 0) {
            prefab = prefab.transform.GetChild(0).GetComponent<SayingScript>();
            GetSayingScriptFromPrefab();
        }
        else {
            //if (sc != null) return;
            if (prefab.nextCardA != null) {
                prefab = prefab.nextCardA.GetComponent<SayingScript>();
                GetSayingScriptFromPrefab();
            }
            else {
                prefab = null;
                GetRandomFromList();
            }
        }

    }
    public void ChangePrefabToB() {
        if (choiceBTxt.text == choiceATxt.text) {
            ChangePrefabToA();
            return;
        }
        if (prefab == null) return;

        //UpdateVariable(sc.passionB, sc.peopleB, sc.gunB, sc.moneyB);
        UpdateVariable(prefab.passionB, prefab.peopleB, prefab.gunB, prefab.moneyB);
        EtcSetting(prefab.etcB);

        if (prefab.transform.childCount > 1) {
            prefab = prefab.transform.GetChild(1).GetComponent<SayingScript>();
            GetSayingScriptFromPrefab();
        }
        else {
            //SayingScript ss = prefab.GetComponent<SayingScript>();
            if (prefab.nextCardB != null) {
                prefab = prefab.nextCardB.GetComponent<SayingScript>();
                GetSayingScriptFromPrefab();
            }
            else {
                prefab = null;
                GetRandomFromList();
            }
        }

    }

    //������ ���빰(content, name, choices)�� �ٲ�
    public void ChangeContent(string c_name, string content, string cA, string cB) {
        nameTxt.text = c_name;

        explainTxt.enabled = c_name.Equals("����");


        //nameImg.enabled = !c_name.Equals("");

        if (c_name.Equals("����")) {
            explainTxt.text = content;
            contentTxt.text = "";
        }
        else {
            contentTxt.text = content;
        }


        choiceATxt.text = cA;
        //choiceA.gameObject.SetActive(!cA.Equals(""));
        choiceBTxt.text = cB;
        if (cB.Equals("")) choiceBTxt.text = cA;
        cc.blackback.gameObject.SetActive(!c_name.Equals("����"));
        //choiceB.gameObject.SetActive(!cB.Equals(""));
    }

    public void ChangeIllust(string c_cmd) {
        spineObj.SetActive(true);
        tempObj.SetActive(false);
        cardIllust.gameObject.SetActive(false);
        //spriteRender.sprite = null;
        string hex = "#FFFFFF"; //#c3c3c3
        c_cmd = c_cmd.ToUpper();
        if (c_cmd.Equals("ENJ"))
        {//������
            hex = "#986D69";

            spriteRender.sprite = temp_Enj;
            spineObj.SetActive(false);
            tempObj.SetActive(true);
        }
        else if (c_cmd.Equals("R"))
        {//�׶��׸�
            hex = "#769289";
            spriteRender.sprite = temp_R;
            spineObj.SetActive(false);
            tempObj.SetActive(true);
        }
        else if (c_cmd.Equals("JOLY"))
        {//����
            hex = "#928076";
            spriteRender.sprite = temp_Joly;
            spineObj.SetActive(false);
            tempObj.SetActive(true);
        }
        else if (c_cmd.Equals("COM"))
        {//����丣
            hex = "#a7cccb";
            spriteRender.sprite = temp_Comb;
            spineObj.SetActive(false);
            tempObj.SetActive(true);
        }
        else if (c_cmd.Equals("COURF"))
        {//�����
            hex = "#c7b79b";
            spriteRender.sprite = temp_Courf;
            spineObj.SetActive(false);
            tempObj.SetActive(true);
        }
        else if (c_cmd.Equals("FLY"))
        {//ǣ��
            hex = "#4a5c4d";
            spriteRender.sprite = temp_Feui;
            spineObj.SetActive(false);
            tempObj.SetActive(true);
        }
        else if (c_cmd.Equals("BAH"))
        {//�ٿ���
            hex = "#b57272";
            spriteRender.sprite = temp_Baho;
            spineObj.SetActive(false);
            tempObj.SetActive(true);
        }
        else if (c_cmd.Equals("BOS"))
        {//������
            hex = "#9c8ead";
            spriteRender.sprite = temp_Boss;
            spineObj.SetActive(false);
            tempObj.SetActive(true);
        }
        else if (c_cmd.Equals("JEH"))
        {//���
            hex = "#c9dbab";
            spriteRender.sprite = temp_Jehan;
            spineObj.SetActive(false);
            tempObj.SetActive(true);
        }
        else if (c_cmd.Equals("MAR"))
        {//�����콺
            hex = "#939ecc";
            spriteRender.sprite = temp_Mari;
            spineObj.SetActive(false);
            tempObj.SetActive(true);
        }
        else if (c_cmd.Equals("GAV"))
        {//����ν�
            hex = "#d18f49";
            spineObj.SetActive(false);
        }
        else if (c_cmd.Equals("EPO"))
        {//������
            hex = "#73593e";
            spineObj.SetActive(false);
        }
        else if (c_cmd.Equals("JVJ"))
        {//�����
            hex = "#54514e";
            spineObj.SetActive(false);
        }
        else if (c_cmd.Equals("JAV"))
        {//�ں���
            hex = "#4e4f54";
            spineObj.SetActive(false);
        }
        else if (c_cmd.Equals("THE"))
        {//�׳����� 
            hex = "#798c7a";
            spriteRender.sprite = temp_Then;
            spineObj.SetActive(false);
            tempObj.SetActive(true);
        }
        else {
            if (c_cmd.Contains("ON_")) {
                hex = "#ffffff";
                if (c_cmd.Contains("DEATH")) {
                    
                }
                else if (c_cmd.Contains("MEMORY"))
                {
                    string[] str = c_cmd.Split(".");

                    cardIllust.sprite = cm.FindSpriteOnCollection("MEMORY", str[1]);
                    cardIllust.gameObject.SetActive(true);
                }
                
            }
            spineObj.SetActive(false);
        }

        Color color;
        ColorUtility.TryParseHtmlString(hex, out color);
        cardImg.color = color;

    }


    public void SetDateAndDay(string year, string month, string day) {
        dateTxt.text = $"{year}�� {month}�� {day}��";


    }
    /// 1830 ��� 157��(7.27~12.31)
    /// 1831 ��� 365��(1.1~12.31)
    /// 1832 ���� 158��(1.1~6.6) �� 680��

    public int CalculateLeftDays(int year, int month, int day) {


        int totalLeftDays = 0;

        //int y = 1832 - year;
        for (int y = year; y <= 1832; y++) {
            int leftDays = 0;
            int[] monDays = { 31, (y == 1832) ? 29 : 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int m, d;
            if (y == year) {
                m = (y == 1832 ? 6 : 12) - month; //1832���Ͻ� 6��-��
                d = (y == 1832 ? 6 : monDays[month - 1]) - day; //1832���Ͻ� 6��-��

            }
            else {
                m = (y == 1832 ? 6 : 12) - 1;
                d = (y == 1832 ? 6 : monDays[month - 1]) - 1;
                d++;
            }

            for (int i = 0; i < m; i++) {
                leftDays += monDays[i];
            }
            leftDays += d;
            totalLeftDays += leftDays;
            //Debug.Log(leftDays + "//" + y + "//" + totalLeftDays);
        }

        //Debug.Log(totalLeftDays);
        return totalLeftDays;
    }



}
