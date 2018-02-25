using UnityEngine;
using System.Collections;

public enum GunType
{
	None,
	Pistol,
	Shotgun
}

public class Gun : BaseTouchable {

	public GunType gunType;

}
