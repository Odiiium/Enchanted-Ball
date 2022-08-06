using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBarView : MonoBehaviour
{
    internal Image HealthImage { get => healthImage ??= transform.GetChild(1).GetComponent<Image>(); }
    Image healthImage;

    internal void FillTheHealthBar(float health, float maxHealth) => HealthImage.fillAmount = health / maxHealth;
}