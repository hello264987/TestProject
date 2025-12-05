using UnityEditor;
using UnityEngine;

public class RenameAsset : EditorWindow
{
    private Object targetAsset;
    [MenuItem("Tools/RenameAsset")]
    private static void Open()
    {
        GetWindow<RenameAsset>("RenameAssetWindow");
    }

    void OnGUI()
    {
        GUILayout.Label("選擇要重新命名的資產", EditorStyles.boldLabel);

        targetAsset = EditorGUILayout.ObjectField("資產:", targetAsset, typeof(Object), false);


        GUILayout.Space(10);

        if (GUILayout.Button("重新命名") && targetAsset != null)
        {
            BatchRename();
        }
    }

    private void BatchRename()
    {
        string folderPath = AssetDatabase.GetAssetPath(targetAsset);
        if (!AssetDatabase.IsValidFolder(folderPath))
        {
            Debug.LogError("選到的不是資料夾");
            return;
        }

        string[] guids = AssetDatabase.FindAssets("t:Texture2D", new[] { folderPath });

        //依照原本的順序
        for (int i = 0; i < guids.Length; i++)
        {
/*             //知道他原本的名字
            string assetPath = AssetDatabase.GUIDToAssetPath(guids[i]);
            string fullFileName = Path.GetFileName(assetPath);
            Debug.LogError(fullFileName); */

            string path = AssetDatabase.GUIDToAssetPath(guids[i]);
            Object tex = AssetDatabase.LoadAssetAtPath<Texture2D>(path);


            string newName = i.ToString("D2"); // 00, 01, 02...
            AssetDatabase.RenameAsset(path, newName);
        }
        Debug.Log($"已成功重新命名 {guids.Length} 張圖片");
    }
}