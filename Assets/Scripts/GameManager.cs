using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public TextMeshProUGUI Tiempo;
    public TextMeshProUGUI VidasdelPlayer;
    public float TimE = 0;
    void Update()
    {
        TimE = TimE + Time.deltaTime;
        Tiempo.text = "TIEMPO: " + TimE.ToString("F0");
        VidasdelPlayer.text = "Vidas: " + Player.GetComponent<CONTROLES>().Vidas;
    }
    private void OnDestroy()
    {
        PlayerPrefs.SetFloat("TiempoGuardado", TimE);
        PlayerPrefs.Save();
    }
}
