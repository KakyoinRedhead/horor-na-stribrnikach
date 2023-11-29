using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class AchivementsScript : MonoBehaviour
{
    public GameObject achivementPopUp;
    public Image achImage;
    public TextMeshProUGUI achText;
    public GameObject player;

    public Sprite startImage;
    public Sprite deadImage;


    public LayerMask groundLayer;
    public LayerMask killerLayer;


    private RaycastHit hit;
    private bool achStartShowed = false;
    private bool achDeadShowed = false;

    void Start()
    {
    }

    void Update()
    {
        AchivementControl();
    }
    private void ShowAchivement()
    {
        achivementPopUp.SetActive(true);
        Invoke("HideAchivement", 4f);
    }
    private void HideAchivement() 
    {
        achivementPopUp.SetActive(false);
    }
    private void AchivementControl()
    {
        if (IsPlayerTouchingGround() && achStartShowed == false)
        {
            achStartShowed = true;
            achImage.sprite = startImage;
            achText.text = "start the game!";
            ShowAchivement();
        } 
        else if (CheckForCollision() && achDeadShowed == false)
        {
            achDeadShowed = true;
            achImage.sprite = deadImage;
            achText.text = "you are dead!";
            ShowAchivement();
        }

    }

    bool IsPlayerTouchingGround()
    {
        Ray ray = new Ray(player.transform.position, Vector3.down);

        float maxDistance = 1.0f;

        if (Physics.Raycast(ray, maxDistance, groundLayer))
        {
            return true;
        }

        return false;
    }
    bool CheckForCollision()
    {
        Ray ray = new Ray(player.transform.position, player.transform.forward);
        RaycastHit hit;

        float raycastDistance = 2f;

        if (Physics.Raycast(ray, out hit, raycastDistance, killerLayer))
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Killer"))
            {
                return true;
            }
        }

        return false;
    }
}
