using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewDataHolder", menuName="Data/New Data Holder")]
[System.Serializable]
public class DataHolder : ScriptableObject
{
    public List<Object> scenes;

    public string[] chap;
    //chap[0] = prologue

    public List<NameSet> storyline;
    public List<NameSet> deathCol;
    public List<NameSet> memoryCol;
    public List<NameSet> peopleCol;
    public List<NameSet> placeCol;

}
