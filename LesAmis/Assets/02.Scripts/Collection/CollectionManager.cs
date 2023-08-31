using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionManager : MonoBehaviour
{
    public List<NameSet> Storyline;
    public List<NameSet> DeathCol;
    public List<NameSet> MemoryCol;
    public List<NameSet> PeopleCol;
    public List<NameSet> PlaceCol;

    public int FoundCards=0;

    public Transform storyTrans;
    public Transform deathTrans;
    public Transform memoryTrans;
    public Transform peopleTrans;
    public Transform placeTrans;

    void Start() {
        /*Debug.Log(Storyline.Count);
        Debug.Log(DeathCol.Count);
        Debug.Log(MemoryCol.Count);
        Debug.Log(PeopleCol.Count);
        Debug.Log(PlaceCol.Count);*/
        if (Storyline.Count < storyTrans.childCount) Storyline = GetList(storyTrans);
        if (DeathCol.Count < deathTrans.childCount) DeathCol = GetList(deathTrans);
        if (MemoryCol.Count < memoryTrans.childCount) MemoryCol = GetList(memoryTrans);
        if (PeopleCol.Count < peopleTrans.childCount) PeopleCol = GetList(peopleTrans);
        if (PlaceCol.Count < placeTrans.childCount) PlaceCol = GetList(placeTrans);
    }


    List<NameSet> GetList(Transform trans) {
        List<NameSet> list=new List<NameSet>();
        Debug.Log(trans+""+trans.childCount);
        for (int i = 0; i < trans.childCount; i++) {
            if(trans.GetChild(i).GetComponent<NameSet>()!=null) list.Add(trans.GetChild(i).GetComponent<NameSet>());
        }
        return list;
    }

    public void SaveDeathCol(string name, int looptime) {
        Debug.Log("저장하겠습니다! " + name);
        for (int i = 0; i < DeathCol.Count; i++) {
            if (DeathCol[i].Name.Equals(name)) {
                DeathCol[i].isCollect = looptime;
                SaveManager.SaveCollection("deathcol", name, looptime);
                Debug.Log("저장+" + name);
                return;
            }
        }
    }

    public void SaveMemoryCol(string name, int looptime)
    {
        Debug.Log("저장하겠습니다! " + name);
        for (int i = 0; i < MemoryCol.Count; i++)
        {
            if (MemoryCol[i].Name.Equals(name))
            {
               if (MemoryCol[i].isCollect<=-1) MemoryCol[i].isCollect = looptime;
                SaveManager.SaveCollection("memorycol", name, looptime);
                Debug.Log("저장+"+name+ MemoryCol[i]);
                return;
            }
        }
    }

    public void ResetCollectionData()
    {
        SaveManager.ResetCollection();
    }

//"storyline", "deathcol", "memorycol", "peoplecol", "placecol" };
    public void LoadMemory() {
        string[] data=SaveManager.LoadData("memorycol");
        if (data.Length.Equals(0)) return; 
        Debug.Log(data[0]);
        for (int i = 0; i < MemoryCol.Count; i++)
        {
            for (int n = 0; n < data.Length; n++) {
                string[] loopdata = data[n].Split("_");
               
                if (MemoryCol[i].Name.Equals(loopdata[0])) {
                    Debug.Log(loopdata[0]);
                    MemoryCol[i].isCollect = int.Parse(loopdata[1]);
                    MemoryCol[i].UpdateCol();
                }
            }
            
        }
    }

    public void LoadDeath()
    {
        string[] data = SaveManager.LoadData("deathcol");
        if (data.Length.Equals(0)) return;
        Debug.Log(data[0]);
        for (int i = 0; i < DeathCol.Count; i++)
        {
            
            for (int n = 0; n < data.Length; n++)
            {
                string[] loopdata = data[n].Split("_");
                
                if (DeathCol[i].Name.Equals(loopdata[0]))
                {
                    Debug.Log(loopdata[0]);
                    DeathCol[i].isCollect = int.Parse(loopdata[1]);
                    DeathCol[i].UpdateCol();
                }
            }

        }
    }

    public Sprite FindSpriteOnCollection(string code, string colName) {
        Sprite sprite=null;
        
        if (code.Equals("DEATH")) {
            
        }
        else if (code.Equals("MEMORY"))
        {
            for (int i = 0; i < MemoryCol.Count; i++)
            {
                if (MemoryCol[i].Name.Equals(colName))
                {
                    
                    sprite = MemoryCol[i].backImg.sprite;
                    break;
                }
            }
        }
        return sprite;
    }

}
