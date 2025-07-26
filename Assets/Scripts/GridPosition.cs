using UnityEngine;
using UnityEngine.EventSystems;

public class GridPosition : MonoBehaviour
{
    [SerializeField] private int x;
    [SerializeField] private int y;

    public void OnMouseDown()
    {
        Debug.Log("Click: " + x + " " + y);
        GameManager.Instance.ClickedOnGridPositionRpc(x, y, GameManager.Instance.GetLocalPlayerType());
    }
}
