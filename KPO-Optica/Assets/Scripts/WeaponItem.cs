using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : MonoBehaviour {

    private Transform playerPos;
    public GameObject equip;
    public GameObject ShadowPlayer;
    private Transform player;
    private static GameObject Tool;
    private static GameObject Light;
    private static bool created;
    private void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Use() {
        if (created == false) {

            //Cast Instantiate naar Gameobjects
            Tool = Instantiate(equip, playerPos.position, equip.transform.rotation, playerPos.transform);
            Light = Instantiate(ShadowPlayer, playerPos.position, ShadowPlayer.transform.rotation, playerPos.transform);
            created = true;
            //Verwijder item inventaris slot
        } else {
            Destroy(gameObject);
            //Verwijder de 2 aangemaakte clones
            Destroy(Tool);
            Destroy(Light);
            //Spawn het item opnieuw terug
            Instantiate(equip, playerPos.position, Quaternion.identity);
            created = false;
        }
    }
}
