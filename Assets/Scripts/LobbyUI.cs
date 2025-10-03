using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LobbyUI : MonoBehaviour
{
    public static LobbyUI Instance { get; private set; }

    [SerializeField] private Button playerNameBtn;
    [SerializeField] private Button authenticateBtn;

    TextMeshProUGUI playerNameTextMesh;

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
            Hide();
        }
        else
        {
            Show();
        }

        playerNameBtn.GetComponentInChildren<TextMeshProUGUI>();

        playerNameBtn.onClick.AddListener(() => { Debug.Log("ChangeName"); });
        authenticateBtn.onClick.AddListener(() =>
        {
            string playerName = playerNameTextMesh.text;

            LobbyManager.Instance.Authenticate(playerName);
        });
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
