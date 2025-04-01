using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Notification : MonoBehaviour
{
    public void OnClickWarning()
    {
        transform.GetChild(0).gameObject.SetActive(!transform.GetChild(0).gameObject.activeSelf);
    }
}
