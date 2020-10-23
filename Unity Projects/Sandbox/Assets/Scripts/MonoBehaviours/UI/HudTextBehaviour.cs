using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class HudTextBehaviour : MonoBehaviour
{
    public ScriptableData[] datas;
    private Text textObj;

    private void Start()
    {
        textObj = GetComponent<Text>();
    }

    private void Update()
    {
        var text = "";
        foreach (var data in datas)
        {
            text += data.GetString() + "\n";
        }

        textObj.text = text;
    }
}
