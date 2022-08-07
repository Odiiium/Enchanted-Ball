using System.Collections;
using UnityEngine;
using UnityEngine.UI;

internal class EnemyHealthBarView : MonoBehaviour
{
    float elapsedTime;
    float updateSpeed = .3f;
    Image HealthBarImage { get => healthBarImage ??= transform.GetChild(1).GetComponent<Image>(); }
    Image healthBarImage;
    internal IEnumerator FillHealthBarImage(float health, float maxHealth)
    {
        float prechangeFillAmountValue = HealthBarImage.fillAmount;
        elapsedTime = 0;
        while (elapsedTime < updateSpeed)
        {
            elapsedTime += Time.deltaTime;
            HealthBarImage.fillAmount = Mathf.Lerp(prechangeFillAmountValue, health/maxHealth, elapsedTime / updateSpeed);
            yield return null;
        }
        HealthBarImage.fillAmount = health / maxHealth;
    }
}
