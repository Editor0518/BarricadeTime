using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SayingScript : MonoBehaviour
{
    public string c_name;//캐릭터 이름
    public string c_cmd;//캐릭터 라투디 설정용
    [TextArea(3, 13)]
    public string content;//문장 내용
    //[TextArea(3, 13)]
    //public string content_drunk;//취했을 때 문장 내용
    public string dateToSet="";//지정할 날짜 (사용을 권장하지 않음)

    [Header("Sound")]
    public AudioClip seToPlay;
    public AudioClip vceToPlay;
    public AudioClip bgmToChange;


    [Header("A")]
    public string choiceA;//선택지A 내용
    [Range(-100,100)]
    public int passionA = 0;//영향 줄 열정
    [Range(-100, 100)]
    public int peopleA = 0;//영향 줄 사람
    [Range(-100, 100)]
    public int gunA = 0;//영향 줄 무기
    [Range(-100, 100)]
    public int moneyA = 0;//영향 줄 자금

    public int daysAddA = 0;//더할 날짜
    [TextArea(1, 2)] public string etcA;//그외 커맨드 (예: 사망, 술 취함 등)
    public GameObject nextCardA;

    [Header("B")]
    public string choiceB;
    [Range(-100, 100)]
    public int passionB = 0;
    [Range(-100, 100)]
    public int peopleB = 0;
    [Range(-100, 100)]
    public int gunB = 0;
    [Range(-100, 100)]
    public int moneyB = 0;
    public float daysAddB = 0;
    [TextArea(1,2)] public string etcB;
    public GameObject nextCardB;

}
