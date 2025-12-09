using UnityEngine;
using TMPro;   // Required for TextMeshProUGUI

public class SymptomsUIController : MonoBehaviour
{
    public TextMeshProUGUI symptomsText;

    public void ShowHistoryExam()
    {
        symptomsText.text =
            "History & Exam\n\n" +
            "• 78-year-old male with recent stroke resulting in dysphagia (difficulty swallowing).\n" +
            "• Physical Exam: Low oxygen saturation (90%) and crackles heard in the right lower lobe (RLL).";
    }

    public void ShowInvestigations()
    {
        symptomsText.text =
            "Investigations\n\n" +
            "• Blood Tests: Elevated White Blood Cell (WBC) count.\n" +
            "• Swallowing Assessment: Needed to assess dysphagia severity.";
    }

    public void ShowDiagnosis()
    {
        symptomsText.text =
            "Diagnosis 🎯\n\n" +
            "• Final diagnosis: Aspiration Pneumonia.\n" +
            "• Based on dysphagia, foul-smelling sputum, and RLL consolidation.";
    }

    public void ShowExploreAnatomy()
    {
        symptomsText.text =
            "Explore Anatomy 🧠\n\n" +
            "Mechanism:\n" +
            "• Stroke impaired swallowing, epiglottis fails to close.\n" +
            "• Food/liquid enters airway.\n\n" +
            "Why RLL?\n" +
            "• Right bronchus is wider, shorter, and more vertical.\n" +
            "• Gravity directs aspirated material into RLL.";
    }
}
