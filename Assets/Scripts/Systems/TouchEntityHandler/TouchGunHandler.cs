using UnityEngine;
using System.Collections;

public class TouchGunHandler : ITouchEntityHandler {
	#region ITouchEntityHandler implementation

	public void Handle (BaseTouchable entity)
	{
		var gun = entity as Gun;

		var w = GetWeapon(gun.gunType);

		var weaponSystem = SystemMgr.Instance.GetSystem<WeaponSystem>();
		weaponSystem.SetCurrentWeapon(w);

		Object.Destroy(entity.gameObject);
	}

	private Weapon GetWeapon(GunType t)
	{
		Weapon w = new Weapon();
		w.weaponType = t;
		if (t == GunType.Pistol)
		{
			w.bulletResPath = "Prefabs/Model/PistolBullet";
			w.bulletSpeed = 6f;
			w.shootCD = 0.6f;
			w.propsResPath = "Prefabs/Model/Pistol";
		}
		else
		{
			w.bulletResPath = "Prefabs/Model/ShotgunBullet";
			w.bulletSpeed = 8f;
			w.shootCD = 1f;
			w.propsResPath = "Prefabs/Model/Shotgun";
		}

		return w;
	}

	#endregion




}
