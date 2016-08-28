using UnityEngine;
using System.Collections;

public class BackButtonView : MonoBehaviour
{
    public void OnClick()
    {
        GamePanelManager.Instance.ShowCityPanel();
    }
}
