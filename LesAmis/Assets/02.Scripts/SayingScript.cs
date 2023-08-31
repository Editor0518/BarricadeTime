using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SayingScript : MonoBehaviour
{
    public string c_name;//ĳ���� �̸�
    public string c_cmd;//ĳ���� ������ ������
    [TextArea(3, 13)]
    public string content;//���� ����
    //[TextArea(3, 13)]
    //public string content_drunk;//������ �� ���� ����
    public string dateToSet="";//������ ��¥ (����� �������� ����)

    [Header("Sound")]
    public AudioClip seToPlay;
    public AudioClip vceToPlay;
    public AudioClip bgmToChange;


    [Header("A")]
    public string choiceA;//������A ����
    [Range(-100,100)]
    public int passionA = 0;//���� �� ����
    [Range(-100, 100)]
    public int peopleA = 0;//���� �� ���
    [Range(-100, 100)]
    public int gunA = 0;//���� �� ����
    [Range(-100, 100)]
    public int moneyA = 0;//���� �� �ڱ�

    public int daysAddA = 0;//���� ��¥
    [TextArea(1, 2)] public string etcA;//�׿� Ŀ�ǵ� (��: ���, �� ���� ��)
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
