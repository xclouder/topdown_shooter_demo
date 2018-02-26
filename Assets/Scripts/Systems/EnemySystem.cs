using UnityEngine;
using System.Collections;

public class EnemySystem : MonoBehaviour, ISystem {

	public int enemyCount = 80;

	#region ISystem implementation

	public void Init ()
	{
		SpawnEnemy();
	}

	public void Reset ()
	{
		
	}

	public void LogicUpdate ()
	{
		
	}

	public void Release ()
	{
		
	}

	#endregion

	void SpawnEnemy()
	{
		var prefab = Resources.Load("Prefabs/Model/Enemy");
		var enemyContainerTr = GameObject.FindWithTag("EnemyContainer").transform;
		for (int i = 0; i < enemyCount; i++)
		{
			var enemyObj = GameObject.Instantiate(prefab) as GameObject;
			var enemyTr = enemyObj.transform;
			enemyTr.SetParent(enemyContainerTr);

			var pos = GameUtils.GetRandomPositionInArena();
			//pos.y = 0.25f;
			enemyTr.position = pos;
		}
	}

}
