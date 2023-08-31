using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainVariable : MonoBehaviour
{

    public int numOfLoop = 0;
    public int currentStep = 0; //현재 날짜 상으로 어느 단계인지.

    [System.Serializable]
    public struct StrInt {
        public string strValue;
        public int intValue; //0= NO, 1=Yes, -1=Before
        
    }
    public StrInt[] death;

    public StrInt[] variable;


    public void AddDeathNew(string deathName) {
        
    }

    public void LoopTimesPlusOne() {
        numOfLoop++;
    }

    public void ResetEverything() {
        numOfLoop = 0;
    }




}
