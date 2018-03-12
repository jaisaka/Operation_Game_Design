using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "Gun", order = 1)]
public class Gun : ScriptableObject {
	public string objName = "New Gun";
	public string[] fireModes;
	public int damagePerShot;
	public Sprite gunSprite;
}
