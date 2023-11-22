using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private PlayerControls playerControls;
    private Animator myAnimator;
    private PlayerController playerController;
    private ActiveWeapon activeWeapon;

    private void Awake() 
    {
        playerController = GetComponentInParent<PlayerController>();
        activeWeapon = GetComponentInParent<ActiveWeapon>();
        myAnimator = GetComponent<Animator>();
        playerControls = new PlayerControls();
    }

    private void OnEnable() {
        playerControls.Enable();
    }
    
    void Start()
    {
        playerControls.Combat.Attack.started += _ => Attack();
    }

    private void Update() 
    {
        MouseFollowWithOffset();
    }

    private void Attack()
    {
        myAnimator.SetTrigger("Attack");
    }

    private void MouseFollowWithOffset()
    {
        UnityEngine.Vector3 mousePos = Input.mousePosition;
        UnityEngine.Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(playerController.transform.position);

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        if(mousePos.x < playerScreenPoint.x)
        {
            activeWeapon.transform.rotation = UnityEngine.Quaternion.Euler(0, -180, angle);
        }
        else
        {
            activeWeapon.transform.rotation = UnityEngine.Quaternion.Euler(0, 0, angle);
        }
    }

    
}
