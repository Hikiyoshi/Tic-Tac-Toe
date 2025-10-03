using System;
using System.Collections.Generic;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LobbyListUI : MonoBehaviour
{
    public static LobbyListUI Instance { get; private set; }

    [SerializeField] private Transform container;
    [SerializeField] private Transform lobbySingleTemplate; //Prefabs lobbySingleTemplate
    [SerializeField] private Button createLobbyBtn;
    [SerializeField] private Button refreshBtn;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        if (LobbyManager.Instance.IsInitialize())
        {
            // Show();
        }
        else
        {
            // Hide();
        }

        createLobbyBtn.onClick.AddListener(CreateLobbyButtonClick);
        refreshBtn.onClick.AddListener(RefreshButtonClick);
    }

    private void CreateLobbyButtonClick()
    {
        Debug.Log("Show Create Lobby");
    }

    private void RefreshButtonClick()
    {
        Debug.Log("Refresh Lobby");
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void UpdateLobbyList(List<Lobby> lobbyList)
    {
        foreach (Transform chill in container)
        {
            if (chill == lobbySingleTemplate) continue;

            Destroy(chill);
        }

        foreach (Lobby lobby in lobbyList)
        {
            Transform lobbySingleTransform = Instantiate(lobbySingleTemplate, container);
            LobbyListSingleUI lobbyListSingleUI = lobbySingleTransform.GetComponent<LobbyListSingleUI>();
            lobbyListSingleUI.UpdateLobby(lobby);
        }
    }
}
