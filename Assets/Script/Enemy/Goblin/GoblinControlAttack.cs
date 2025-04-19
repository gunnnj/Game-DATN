using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinControlAttack : MonoBehaviour
{
    public BoxCollider weapon;
    //Add event anim
    public void EventStartAttack(){
        weapon.enabled = true;
    }
    public void EventEndAttack(){
        weapon.enabled = false;
    }
}
