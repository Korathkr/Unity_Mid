using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class SkillBtn : MonoBehaviour
{
    private float cooltime = 10f;       //현재 남은 시간
    private float cooltime_max = 10f;   //쿨타임
    public Text timer;  //남은 시간을 표시할 텍스트
    public Image disable;   //남은 시간을 표시할 이미지

    IEnumerator CoolTimeFunc()
    {
        while (cooltime > 0.0f)
        {
            cooltime -= Time.deltaTime;

            //쿨타임 이미지
            disable.fillAmount = cooltime / cooltime_max;

            //쿨타임 텍스트
            string t = TimeSpan.FromSeconds(cooltime).ToString("s\\:ff");
            string[] tokens = t.Split(':');
            timer.text = string.Format("{0}:{1}", tokens[0], tokens[1]);

            yield return new WaitForFixedUpdate();
        }
    }
}