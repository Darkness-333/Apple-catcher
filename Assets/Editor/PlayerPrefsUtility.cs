using UnityEngine;
using UnityEditor;

public class PlayerPrefsUtility : MonoBehaviour {
    // ƒобавл€ем пункт меню дл€ обнулени€ всех PlayerPrefs
    [MenuItem("Tools/Reset All PlayerPrefs")]
    public static void ResetPlayerPrefs() {
        if (EditorUtility.DisplayDialog("Reset PlayerPrefs",
            "Are you sure you want to reset all PlayerPrefs? This action cannot be undone.",
            "Yes", "No")) {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
            EditorUtility.DisplayDialog("Reset PlayerPrefs", "All PlayerPrefs have been reset.", "OK");
        }
    }
}
