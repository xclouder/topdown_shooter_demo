using UnityEngine;
using System.Collections;

public class Weapon
{
	public GunType weaponType;
	public float bulletSpeed;
	public float shootCD;
	public string bulletResPath;
	public string propsResPath;
}

public class WeaponSystem : MonoBehaviour, ISystem {
	#region ISystem implementation

	public void Init ()
	{
		
	}

	public void Reset ()
	{
		
	}

	public void LogicUpdate ()
	{
		if (m_currWeapon == null)
		{
			return;
		}

		if (Input.GetMouseButton(0))
		{
			if (Time.time - previousShootTime >= m_currWeapon.shootCD)
			{
				previousShootTime = Time.time;

				Shoot();
			}	
		}
	}

	private GameObject m_bulletPrefab;
	private Transform m_shootPointTr;
	void Shoot()
	{
		Debug.Log("shoot");

		if (m_shootPointTr == null)
		{
			var playerObj = GameObject.FindWithTag("Player");
			m_shootPointTr = playerObj.transform.Find("ShootPoint");
		}

		var startPos = m_shootPointTr.position;
		var dir = m_shootPointTr.forward;

		var bulletObj = GameObject.Instantiate(m_bulletPrefab);
		var bullet = bulletObj.GetComponent<Bullet>();
		bullet.speed = m_currWeapon.bulletSpeed;
		bullet.transform.position = startPos;
		bullet.transform.forward = dir;

	}

	public void Release ()
	{
		
	}

	#endregion

	private Weapon m_currWeapon = null;

	public Weapon CurrentWeapon
	{
		get 
		{
			return m_currWeapon;
		}
	}

	public void SetCurrentWeapon(Weapon w)
	{
		if (m_currWeapon != null)
		{
			DropCurrentWeapon();
		}


		m_currWeapon = w;

		RefreshCD();

		var bulletPath = m_currWeapon.bulletResPath;
		m_bulletPrefab = Resources.Load(bulletPath) as GameObject;
		if (m_bulletPrefab == null)
		{
			Debug.LogError("prefab is null:" + bulletPath);
		}
	}

	private float previousShootTime = float.MinValue;
	void RefreshCD()
	{
		previousShootTime = float.MinValue;
	}

	void DropCurrentWeapon()
	{
		var p = m_currWeapon.propsResPath;
		var prefab = Resources.Load(p);
		var obj = GameObject.Instantiate(prefab) as GameObject;

		var player = GameObject.FindGameObjectWithTag("Player");
		obj.transform.position = player.transform.position - player.transform.forward * 1f;

	}
}
