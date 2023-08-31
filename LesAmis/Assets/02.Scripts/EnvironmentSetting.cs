using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentSetting : MonoBehaviour
{
    [Header("Outside Light")]
    public UnityEngine.Rendering.Universal.Light2D nightLight;
    public UnityEngine.Rendering.Universal.Light2D dayLight;
    public UnityEngine.Rendering.Universal.Light2D noonLight;
    public UnityEngine.Rendering.Universal.Light2D dawnLight;
    public UnityEngine.Rendering.Universal.Light2D sunsetLight;

    [Header("Inside Light")]
    public UnityEngine.Rendering.Universal.Light2D musainLight;
    public UnityEngine.Rendering.Universal.Light2D corintheLight;


}
