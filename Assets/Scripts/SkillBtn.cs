using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class SkillBtn : MonoBehaviour
{
    private float cooltime = 10f;       //���� ���� �ð�
    private float cooltime_max = 10f;   //��Ÿ��
    public Text timer;  //���� �ð��� ǥ���� �ؽ�Ʈ
    public Image disable;   //���� �ð��� ǥ���� �̹���

    IEnumerator CoolTimeFunc()
    {
        while (cooltime > 0.0f)
        {
            cooltime -= Time.deltaTime;

            //��Ÿ�� �̹���
            disable.fillAmount = cooltime / cooltime_max;

            //��Ÿ�� �ؽ�Ʈ
            string t = TimeSpan.FromSeconds(cooltime).ToString("s\\:ff");
            string[] tokens = t.Split(':');
            timer.text = string.Format("{0}:{1}", tokens[0], tokens[1]);

            yield return new WaitForFixedUpdate();
        }
    }
}