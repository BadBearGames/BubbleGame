using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuManager : Singleton<MenuManager> 
{
	public List<GameObject> uiScreens;

	protected MenuManager() {}

	void Awake()
	{
		
	}
}
