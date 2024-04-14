using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSelectionButton : MonoBehaviour
{
    public Button uiButton;
    public Image paddleReference;
    public bool isColorPlayer = false;

    public void OnButtonClick()
    {
        paddleReference.color = uiButton.colors.normalColor;

        if (isColorPlayer)
        {
            SaveControler.Instance.colorPlayer = paddleReference.color;
        }
        else
        {
            SaveControler.Instance.colorEnemy = paddleReference.color;
        }
    }
}
