using UnityEngine;
using System.Collections;

public interface ISystem {

	void Init();

	void Reset();

	void LogicUpdate();

	void Release();

}
