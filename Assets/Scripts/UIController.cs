using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickAction : MonoBehaviour
{
    void Update()
    {
        // Mouse ձախ քլիկ
        if (Input.GetMouseButtonDown(0))
        {
            DoAction();
        }
    }

    // Նույն ֆունկցիան կկանչվի նաև Button-ից
    public void DoAction()
    {
        Debug.Log("Գործառույթը կատարվեց");
    }
}
