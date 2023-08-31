using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
    public ContentManager cm;
    public ContainVariable cv;
    public VariableManager vm;


    void Start() {
        //StartEtcDeath("�����콺����");
        Debug.Log("�����콺���� ����");
    }
    

    public void StartDeath(int iVar, int iNum) {
        string path = "Death/";

        if (cv.currentStep == 0) { path += "Planning/"; }
        else if (cv.currentStep == 1) { path += "Barricade/"; }
        
        if (iVar == 0 && iNum > 0)
        {
            //passion 100
            path += "����max";
        }
        else if (iVar == 0 && iNum < 0)
        {
            //passion 0
            path += "����min";
        }
        else if (iVar == 1 && iNum > 0)
        {
            //people 100
            path += "����max";
        }
        else if (iVar == 1 && iNum < 0)
        {
            //people 0
            path += "����min";
        }
        else if (iVar == 2 && iNum > 0)
        {
            //gun 100
            path += "����max";
        }
        else if (iVar == 2 && iNum < 0)
        {
            //gun 0
            path += "����min";
        }
        else if (iVar == 3 && iNum > 0)
        {
            //money 100
            path += "�ڱ�max";
        }
        else if (iVar == 3 && iNum < 0)
        {
            //money 0
            path += "�ڱ�min";
        }

        GameObject deathObj = Resources.Load<GameObject>(path);
        cm.stack.AddOneInDeathList(deathObj);
        Debug.Log(path);
        
    }

    public void StartEtcDeath(string fileName) {
        string path = "Death/Etc/" + fileName;
        GameObject deathObj = Resources.Load<GameObject>(path);
        cm.stack.AddOneInDeathList(deathObj);
        string deathName="";

        if (fileName.Equals("�����콺����")) { deathName = "MariusBoom"; }
       
        cv.AddDeathNew(deathName);
    }


}
