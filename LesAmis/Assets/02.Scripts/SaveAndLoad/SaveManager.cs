using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private static string SAVED_GAME = "savedGame";

    public static void SaveGame(SaveData data) {
        PlayerPrefs.SetString(SAVED_GAME, JsonUtility.ToJson(data));
    }

    public static SaveData LoadGame() {
        return JsonUtility.FromJson<SaveData>(PlayerPrefs.GetString(SAVED_GAME));
    }

    public static bool IsGameSaved() {
        return PlayerPrefs.HasKey(SAVED_GAME);
    }

    public static void SaveChapter(string name, string value) {
        string data = PlayerPrefs.GetString(name);
        if (data != "") data += ",";
        data+=value;

        PlayerPrefs.SetString(name, data);
    }

    //컬렉션 세이브하기
    public static void SaveCollection(string code, string name, int loop) {
        code = code.ToLower();
        //code는 무엇을 저장할지 PlayerPrefs string의 이름임.
        if (code != "storyline" && code != "deathcol" && code != "memorycol" && code != "peoplecol" && code != "placecol") {
            Debug.Log("error" + code);
            return;
        }
        //해당 데이터 불러오기
        string data = PlayerPrefs.GetString(code);



        //이미 저장되어 있다면 그곳을 바꿔 덮어쓰기
        if (data.Contains(name))
        {
            string[] datas = data.Split(",");

            for (int i = 0; i < datas.Length; i++)
            {
                if (datas[i].Contains(name))
                {
                    string theData = datas[i];
                    data = data.Replace(theData, name + "_" + loop);
                    break;
                }
            }
        }
        else {
            if (data != "") data += ",";
            data += name + "_" + loop; //한번도 저장한 적 없을 시 새로 추가함.
        }
        
        
        PlayerPrefs.SetString(code, data);//세이브
        Debug.Log(PlayerPrefs.GetString(code));
    }


    public static void ResetCollection() {
        string[] code = { "storyline", "deathcol", "memorycol", "peoplecol", "placecol" };
        for (int i = 0; i < code.Length; i++) {
            PlayerPrefs.SetString(code[i], "");
        }
        
    }

    public static string[] LoadData(string dataName) {
        return PlayerPrefs.GetString(dataName).Split(",");
    }

    public static string[] ReturnChapterData(string name) {
        string[] data = PlayerPrefs.GetString(name).Split(",");
        Debug.Log(data[0]);
        return data;
    }

}
