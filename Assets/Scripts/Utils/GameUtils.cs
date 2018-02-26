using UnityEngine;
using System.Collections;

public static class GameUtils {

	private const float HALF_AREA_WIDTH = 15f;
	private const float HALF_AREA_HEIGHT = 15f;

	public static Vector3 GetRandomPositionInArena()
	{
		var randomX = Random.Range(-HALF_AREA_WIDTH, HALF_AREA_WIDTH);
		var randomZ = Random.Range(-HALF_AREA_HEIGHT, HALF_AREA_HEIGHT);

		return new Vector3(randomX, 0, randomZ);
	}

	public static Vector3 RestrictPositionToArena(Vector3 pos)
	{
		if (pos.x < -HALF_AREA_WIDTH)
		{
			pos.x = -HALF_AREA_WIDTH;
		}

		if (pos.x > HALF_AREA_WIDTH)
		{
			pos.x = HALF_AREA_WIDTH;
		}

		if (pos.z < -HALF_AREA_HEIGHT)
		{
			pos.z = -HALF_AREA_HEIGHT;
		}

		if (pos.z > HALF_AREA_HEIGHT)
		{
			pos.z = HALF_AREA_HEIGHT;
		}

		return pos;
	}

}
