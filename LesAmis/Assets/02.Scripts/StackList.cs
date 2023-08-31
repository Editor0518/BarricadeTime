using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;

public class StackList : MonoBehaviour
{
    [System.Serializable]
    public struct StackWithTime {
        public GameObject stack;
        public int leftDays;

        public StackWithTime(GameObject stack, int leftDays) {
            this.stack = stack;
            this.leftDays = leftDays;
        }
    }

    [System.Serializable]
    public struct StackWithDate
    {
        public GameObject stack;
        public string exactDate;
    }


    public List<GameObject> stackList;
    public List<StackWithTime> stackTimeList;
    public List<StackWithDate> stackDateList;
    public List<GameObject> stackDeathList;


    string path = "Stacks/";//Assets/04.Prefabs/

    public List<string> StacksPaths; //������
    public GameObject NewCardObj;
    public TMP_Text NewCardObjText;

    public void AddNewCards(string Name) {
        string[] str = ReturnPathName(Name);
        bool isExist = false;
        for (int i = 0; i < StacksPaths.Count; i++)
        {
            if (StacksPaths[i].Equals(str[0])) { isExist = true; break; }
        }
        if (!isExist) {
            StacksPaths.Add(str[0]);
            LoadStack(str[0]);
            NewCardObjText.text = str[1];
            NewCardObj.SetActive(true);
        }
    }

    string[] ReturnPathName(string Name) {
        string[] str = new string[2];
        if (Name.Equals("�����콺")) { str[0] = "Marius/"; str[1] = "����� ���� ���� �����콺 ���޸���"; }
        else if (Name.Equals("�����")) {str[0] = "Jean Valjean/"; str[1] = "�� ���� --> ���鷻 ���� --> ����� �� --> ���� ��������"; }
        else if (Name.Equals("x")) {str[0] = "X/"; str[1] = "������ ������ ��� ��ü"; }
        else if (Name.Equals("������")) {str[0] = "Eponine/"; str[1] = "������ �׳�����"; }

        return str;
    }



    private void Start() {
        //stackList = (GameObject)AssetDatabase.LoadAssetAtPath(path+".prefab", typeof(GameObject));
        
    }

    public void ResetAll() {
        stackList = new List<GameObject>();
        stackTimeList = new List<StackWithTime>();
        stackDateList = new List<StackWithDate>();
        stackDeathList = new List<GameObject>();
    }

    public void LoadAll() {
        
        for (int i = 0; i < StacksPaths.Count; i++) {
            LoadStack(StacksPaths[i]);
        }
       
    }

    public void LoadStack(string secPath) {
        List<GameObject> list = Resources.LoadAll<GameObject>(path+ secPath).ToList();

        for (int i = 0; i < list.Count; i++)
        {
            string date = list[i].GetComponent<SayingScript>().dateToSet;

            if (date.Equals(""))
            {
                stackList.Add(list[i]);
            }
            else if (date.Contains("."))
            {
                stackDateList.Add(StackWithDateMaker(list[i], list[i].GetComponent<SayingScript>().dateToSet));
            }
            else
            {
                stackTimeList.Add(StackWithTimeMaker(list[i], int.Parse(list[i].GetComponent<SayingScript>().dateToSet)));
            }
        }

    }


    public StackWithDate StackWithDateMaker(GameObject gameObject, string exactDate) {
        return new StackWithDate { stack = gameObject, exactDate = exactDate };
    }

    public StackWithTime StackWithTimeMaker(GameObject gameObject, int leftDays) {
        return new StackWithTime { stack = gameObject, leftDays = leftDays };
    }

    public void AddOneInDeathList(GameObject obj) {
        if (obj != null) stackDeathList.Add(obj);
        else Debug.Log("null!");
    }
    



}
