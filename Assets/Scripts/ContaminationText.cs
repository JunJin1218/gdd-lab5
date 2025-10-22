using TMPro;
using UnityEngine;

public class ContaminationText : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private int maxContamination = 5;

    public void UpdateContaminationText(int contamination)
    {
        if (text == null)
            text = GetComponent<TMP_Text>();

        text.text = $"{contamination}/{maxContamination}";
    }
}
