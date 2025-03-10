using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RTS/Game Settings/List Build for Resources", fileName = "List Build for Resources")]
public class ListBuildForResources : ScriptableObject
{
   public List<GameObject> BuildPosition = new List<GameObject>();
}
