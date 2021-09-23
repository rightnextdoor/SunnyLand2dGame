using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    [SerializeField] private PlayerStatus status;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;

    private void Start()
    {
        
        totalHealthBar.fillAmount = status.getStartingHealth() / 10;
    }

    private void Update()
    {
        currentHealthBar.fillAmount = status.getPlayerHealth() / 10;
    }
}
