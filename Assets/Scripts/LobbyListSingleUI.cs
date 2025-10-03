using TMPro;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using UnityEngine.UI;

public class LobbyListSingleUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI lobbyNameText;
    [SerializeField] private TextMeshProUGUI playersText;
    [SerializeField] private TextMeshProUGUI gameModeText;

    private Button JoinLobbyBtn;
    private string lobbyCode;

    private void Start()
    {
        JoinLobbyBtn = GetComponent<Button>();
        JoinLobbyBtn.onClick.AddListener(() => Debug.Log("Joined Lobby" + lobbyCode));
    }

    public void UpdateLobby(Lobby lobby)
    {
        lobbyCode = lobby.LobbyCode;

        lobbyNameText.text = lobby.Name;
        playersText.text = lobby.Players.Count + "/" + lobby.MaxPlayers;
        gameModeText.text = lobby.Data[LobbyManager.KEY_GAME_MODE].Value;
    }
}
