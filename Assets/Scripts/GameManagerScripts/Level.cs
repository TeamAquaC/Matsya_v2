using UnityEngine;
using System.Collections;

public class Level
{
	public int levelNumber;
	public bool unlocked;
	public bool completed;

	public Level(int _levelNumber, bool _unlocked, bool _completed)
	{
		levelNumber = _levelNumber;
		unlocked = _unlocked;
		completed = _completed;
	}
}
