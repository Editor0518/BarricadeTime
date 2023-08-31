using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NameSet : MonoBehaviour
{
    public enum TagOfCard{
        story, death, memory, people, place
    }

    public TagOfCard tagcard;
    //public bool isDeath = false;
    public string Name;
    public Image backImg;
    public Color backCol;
    public TMP_Text text;
    public int isCollect=-1;
    //CollectionManager cm;

    void OnEnable() {
        //if (cm == null) cm = GameObject.FindGameObjectWithTag("Collection").GetComponent<CollectionManager>();
        //cm.LoadData(tagcard.ToString(), Name);
        UpdateCol();


    }

    public void UpdateCol()
    {
        if (isCollect >= 0)
        {
            if (tagcard.Equals("death"))
            {
                Debug.Log("death");
                if (text != null) text.text = isCollect + "È¸Â÷";

                return;
            }
            if (text != null) text.text = Name;
            if (backImg != null && backCol != null) { backImg.color = backCol; }
        }
        else
        {
            if (text != null) text.text = "???";
            if (backImg != null && backCol != null) { backImg.color = Color.black; }
        }
    }

    public void PlusOne() {
        isCollect++;
    }

    public void ResetAll() {
        isCollect = -1;
    }


}
