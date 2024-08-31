using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Level ", menuName = "Create level settings")]
public class LevelSettingsSO : ScriptableObject {

    //public int levelNumber;
    public int nextLevelPoints;

    public List<AppleSettings> applesSettings;
    public List<AppleTreeSettings> appleTreesSettings;

    [ContextMenu("SetDefaultLastAppleTreeSettingsElement")]
    private void SetDefaultAppleTreeSettingsElement() {
        if (appleTreesSettings.Count > 0) {
            appleTreesSettings[appleTreesSettings.Count - 1].ResetToDefaultValues();

        }
    }
}
