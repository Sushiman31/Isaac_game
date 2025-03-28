using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public static HealthBar instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de HealthBar dans la scène");
            return;
        }

        instance = this;
    }
     public Slider slider;
   
    public void SetMaxHealth(int _health){ //met la barre de santé au maximum à l'appel
        slider.maxValue=_health;
        slider.value=_health;
    }
    public void SetHealth(int _health){//modifie la barre de vie
        slider.value=_health;
    }
}
