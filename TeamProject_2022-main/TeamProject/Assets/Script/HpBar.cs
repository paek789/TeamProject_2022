using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    [SerializeField]
    Image hpBar;
    [SerializeField]
    Image hpBar_middle;
    float val = 1f;
    public void HealthEffect(float curhealth)
    {
        hpBar.rectTransform.localScale = new Vector3(curhealth, 1f, 1f);
        StartCoroutine("UpdateHpBar", curhealth);
    }
    IEnumerator UpdateHpBar(float curhealth)
    {
        while (val > curhealth)
        {
            val -= 0.001f; 
            yield return new WaitForSeconds(0.01f);
            hpBar_middle.rectTransform.localScale = new Vector3(val, 1f, 1f);
        }
    }
}
