using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class VariableManager : MonoBehaviour
{
    [Header("열정")]
    [Range(0, 100)]
    public int passion = 50;
    public Image passionImg;

    [Header("사람")]
    [Range(0, 100)]
    public int people = 50;
    public Image peopleImg;

    [Header("무기")]
    [Range(0, 100)]
    public int gun = 50;
    public Image gunImg;

    [Header("자금")]
    [Range(0, 100)]
    public int money = 50;
    public Image moneyImg;

    [Header("설정")]
    public Color increase;
    public Color decrease;

    public DeathManager dm;

    float multi = 1.5f;


    public void ChangeVariable(int passionAdd, int peopleAdd, int gunAdd, int moneyAdd)
    {
        passion += (int)(passionAdd * multi);
        people += (int)(peopleAdd * multi);
        gun += (int)(gunAdd * multi);
        money += (int)(moneyAdd * multi);
        StartCoroutine(UpdateImages());


    }

    public void CheckIfDead()
    {
        //더 많이깎인 것을 우선순위 데스로 선정함.
        int[] vars = { passion, people, gun, money };
        int iVar = -1; //0, 1, 2, 3
        int iNum = 0; //-1 or 1

        for (int i = 0; i < 4; i++)
        {
            if (vars[i] >= 100 || vars[i] <= 0)
            {
                for (int n = i; n < 4; n++)
                {
                    
                    if (Math.Abs(vars[i] - (vars[i]<0?100:0)) >= (Math.Abs(vars[n] - (vars[n] < 0 ? 100 : 0)))) { iVar = i; }//110>=100
                    //Debug.Log(Math.Abs(vars[i] - (vars[i] < 0 ? 100 : 0)) + " vs "+ (Math.Abs(vars[n] - (vars[n] < 0 ? 100 : 0))));
                }
            }


        }


        if (iVar < 0) return;
        else
        {

            iNum = vars[iVar] > 0 ? 1 : -1;
            dm.StartDeath(iVar, iNum);
            //Debug.Log(iVar + " iNum=" + iNum);
        }
        
    }


    private void Start()
    {
        ClearVariable();
    }

    public void ClearVariable()
    {
        passion = 50;
        people = 50;
        gun = 50;
        money = 50;
        StartCoroutine(UpdateImages());
    }

    IEnumerator UpdateImages()
    {
        WaitForSeconds wait = new(0.05f);

        while (!IsVarAndFillSame())
        {
            passionImg.fillAmount += MinusOrPlus(passion, (int)(passionImg.fillAmount * 100));
            passionImg.color = ChangeColor(passion, (int)(passionImg.fillAmount * 100));

            peopleImg.fillAmount += MinusOrPlus(people, (int)(peopleImg.fillAmount * 100));
            peopleImg.color = ChangeColor(people, (int)(peopleImg.fillAmount * 100));

            gunImg.fillAmount += MinusOrPlus(gun, (int)(gunImg.fillAmount * 100));
            gunImg.color = ChangeColor(gun, (int)(gunImg.fillAmount * 100));

            moneyImg.fillAmount += MinusOrPlus(money, (int)(moneyImg.fillAmount * 100));
            moneyImg.color = ChangeColor(money, (int)(moneyImg.fillAmount * 100));


            yield return wait;
        }

        yield return null;
    }

    Color ChangeColor(int original, int changed)
    {
        if (MinusOrPlus(original, changed) > 0)
        {
            return increase;
        }
        else if (MinusOrPlus(original, changed) < 0)
        {
            return decrease;
        }
        else return Color.white;
    }

    float MinusOrPlus(int original, int changed)
    {
        if (changed > original) return -.01f;
        if (changed < original) return .01f;
        else return 0;
    }

    bool IsVarAndFillSame()
    {
        int[] imgFillArray = new int[4];
        imgFillArray[0] = (int)(passionImg.fillAmount * 100);
        imgFillArray[1] = (int)(peopleImg.fillAmount * 100);
        imgFillArray[2] = (int)(gunImg.fillAmount * 100);
        imgFillArray[3] = (int)(moneyImg.fillAmount * 100);

        return (imgFillArray[0] == passion && imgFillArray[1] == people && imgFillArray[2] == gun && imgFillArray[3] == money);
    }


}
