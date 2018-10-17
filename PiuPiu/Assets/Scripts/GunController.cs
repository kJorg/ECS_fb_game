using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

    public Transform weaponPlaceholder;
    public Gun startingWeapon;
    Gun equippedGun;    

    void Start()
    {
        if (startingWeapon != null) {
            EquipGun(startingWeapon);
        }
    }

    public void EquipGun(Gun gunToEquip) {
        if (equippedGun != null) {
            Destroy(equippedGun.gameObject);
        }
        equippedGun = Instantiate(gunToEquip, weaponPlaceholder.position, weaponPlaceholder.rotation) as Gun;
        equippedGun.transform.parent = weaponPlaceholder;
    }
    public void Shoot(){
        if (equippedGun != null){
            equippedGun.Shoot();
        }
    }

}
