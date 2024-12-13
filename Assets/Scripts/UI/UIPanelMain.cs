using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanelMain : MonoBehaviour, IMenu
{
    [SerializeField] private Button btnTimer;

    [SerializeField] private Button btnMoves;

    [SerializeField] private Button[] btnThemes;

    private UIMainManager m_mngr;

    private void Awake()
    {
        btnMoves.onClick.AddListener(OnClickMoves);
        btnTimer.onClick.AddListener(OnClickTimer);

        for (int i = 0; i < btnThemes.Length; i++)
        {
            int index = i;
            btnThemes[i].onClick.AddListener(() =>
            {
                OnClickTheme(index);
            });
        }
    }

    private void OnDestroy()
    {
        if (btnMoves) btnMoves.onClick.RemoveAllListeners();
        if (btnTimer) btnTimer.onClick.RemoveAllListeners();

        if (btnThemes!=null)
        {
            for (int i = 0; i < btnThemes.Length; i++)
            {
                btnThemes[i]?.onClick.RemoveAllListeners();
            }
        }   
    }

    private void Start()
    {
        var theme = PlayerPrefs.GetInt("theme");
        OnClickTheme(theme);
    }

    public void Setup(UIMainManager mngr)
    {
        m_mngr = mngr;
    }

    private void OnClickTimer()
    {
        m_mngr.LoadLevelTimer();
    }

    private void OnClickMoves()
    {
        m_mngr.LoadLevelMoves();
    }

    private void OnClickTheme(int index)
    {
        Debug.Log("Click theme: " + index);

        for (int i = 0; i < btnThemes.Length; i++)
        {
            btnThemes[i].transform.GetChild(0).gameObject.SetActive(index == i);
        }

        PlayerPrefs.SetInt("theme", index);
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
}
