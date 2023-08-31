using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
    public ContentManager cm;
    public ContainVariable cv;
    public VariableManager vm;


    void Start() {
        //StartEtcDeath("마리우스폭사");
        Debug.Log("마리우스폭사 시작");
    }
    

    public void StartDeath(int iVar, int iNum) {
        string path = "Death/";

        if (cv.currentStep == 0) { path += "Planning/"; }
        else if (cv.currentStep == 1) { path += "Barricade/"; }
        
        if (iVar == 0 && iNum > 0)
        {
            //passion 100
            path += "열정max";
        }
        else if (iVar == 0 && iNum < 0)
        {
            //passion 0
            path += "열정min";
        }
        else if (iVar == 1 && iNum > 0)
        {
            //people 100
            path += "민중max";
        }
        else if (iVar == 1 && iNum < 0)
        {
            //people 0
            path += "민중min";
        }
        else if (iVar == 2 && iNum > 0)
        {
            //gun 100
            path += "무기max";
        }
        else if (iVar == 2 && iNum < 0)
        {
            //gun 0
            path += "무기min";
        }
        else if (iVar == 3 && iNum > 0)
        {
            //money 100
            path += "자금max";
        }
        else if (iVar == 3 && iNum < 0)
        {
            //money 0
            path += "자금min";
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

        if (fileName.Equals("마리우스폭사")) { deathName = "MariusBoom"; }
       
        cv.AddDeathNew(deathName);
    }


}
