using UnityEngine;
using UnityEditor;

public class TreeViewEditor : Editor 
{
    [MenuItem("GameObject/UI/TreeView")]
    static void CreateTreeView()
    {
        GameObject canvas = GameObject.Find("Canvas");

        if (canvas == null)
        {
            EditorUtility.DisplayDialog("Demander", "Pas de GameObject Canvas！", "OK");
            return;
        }

        GameObject treeView = Instantiate(Resources.Load("TreeView") as GameObject);
        treeView.name = "TreeView";
        treeView.transform.SetParent(canvas.transform);
        treeView.transform.localPosition = Vector3.zero;
        treeView.transform.localScale = Vector3.one;
    }
}
