using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class SkillBarController : MonoBehaviour
{
    public Image imageCooldown;
    public float cooldown = 5.0f;
    bool isCooldown;

    public GameObject skillOn;
    public GameObject skillOff;

    void Start()
    {
        skillOn.SetActive(true);
        isCooldown = true;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isCooldown == false)
        {
            isCooldown = true;
            skillOff.SetActive(true);
            skillOn.SetActive(false);
        }

        if(isCooldown)
        {
            imageCooldown.fillAmount += 1 / cooldown * Time.deltaTime;

            if(imageCooldown.fillAmount >= 1)
            {
                imageCooldown.fillAmount = 0;
                isCooldown = false;
                skillOn.SetActive(true);
                skillOff.SetActive(false);
            }
        }
    }
}
