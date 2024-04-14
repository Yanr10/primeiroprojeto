using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuControler : MonoBehaviour
{

    public TextMeshProUGUI uiWinner;
    void Start()
    {
        
        SaveControler.Instance.Reset();
        string lastWinner = SaveControler.Instance.GetLastWinner();
        if (lastWinner != "")
            uiWinner.text = "Último vencedor: " + lastWinner;
        else
            uiWinner.text = "";
    }
}
   