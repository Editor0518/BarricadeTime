using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSizeOnResoultion : MonoBehaviour
{
    Camera cam;


    // Start is called before the first frame update
    void Start()
    {
        int big, small;


        cam = GetComponent<Camera>();

        if (Screen.height >= Screen.width)
        {
            big = Screen.height;
            small = Screen.width;
        }
        else {
            return;
        }

        float view = big/small;
        view *= 30;
        cam.fieldOfView = (int)view;
    }

 
}
