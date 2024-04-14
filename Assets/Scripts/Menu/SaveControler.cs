using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveControler : MonoBehaviour
{
    public Color colorPlayer = Color.white;
    public Color colorEnemy = Color.white;
    public string namePlayer;
    public string nameEnemy;
    private string saveWinnerKey = "SavedWinner";

    private static SaveControler _instance;
    public static SaveControler Instance

    {
        get
        {
            if (_instance == null)
            {
                // Procure a instância na cena
                _instance = FindObjectOfType<SaveControler>();
                // Se não encontrar, crie uma nova instância
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(SaveControler).Name);
                    _instance = singletonObject.AddComponent<SaveControler>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        // Garanta que apenas uma instância do Singleton exista
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        // Mantenha o Singleton vivo entre as cenas
        DontDestroyOnLoad(this.gameObject);
    }

    public string GetName(bool isPlayer)
    {
        return isPlayer ? namePlayer : nameEnemy;
    }

    public void Reset()
    {
        nameEnemy = "";
        namePlayer = "";
        colorEnemy = Color.white;
        colorPlayer = Color.white;
    }

    public void SaveWinner(string winner)
    {
        PlayerPrefs.SetString(saveWinnerKey, winner);
    }
    public string GetLastWinner()
    {
        return PlayerPrefs.GetString(saveWinnerKey);
    }

    public void ClearSave()
    {
        PlayerPrefs.DeleteAll();
  SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
