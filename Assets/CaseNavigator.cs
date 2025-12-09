using UnityEngine;
using TMPro;

public class CaseNavigator : MonoBehaviour
{
    public TextMeshProUGUI symptomsText;

    public void ShowHistoryExam()
    {
        if (symptomsText == null)
        {
            Debug.LogError("symptomsText is NOT assigned in CaseNavigator!");
            return;
        }

        Debug.Log("History button CLICKED");   // will appear in Console
        symptomsText.text = "HISTORY PANEL TEST";
    }
}
