using TMPro;
using UnityEngine;

public class GripManager : MonoBehaviour
{
    public TMP_Text gripText;
    public string gripStatus;
    public static GripManager Instance;

    void Awake()
    {
        Instance = this;
    }

    public void UpdateGrip(string grip)
    {
        gripText.text = grip;
        gripStatus = grip;
        Debug.Log("Nowy grip: " + gripStatus);
    }
}
