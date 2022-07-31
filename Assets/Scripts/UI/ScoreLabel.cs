using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreLabel : MonoBehaviour
{
    #region Variables

    private TextMeshProUGUI _scoreLabel;

    #endregion


    #region Unity Lifecycle
    
    private void Awake()
    {
        _scoreLabel = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _scoreLabel.text = $"Score: {Statistics.Instance.Points}";
    }

    #endregion
}