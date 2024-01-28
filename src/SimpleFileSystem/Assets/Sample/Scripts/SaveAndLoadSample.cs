using UnityEngine;
using UnityEngine.UI;

namespace SimpleFileSystem.Sample
{
    public class SaveAndLoadSample : MonoBehaviour
    {
        [System.Serializable]
        private class SaveData
        {
            [SerializeField]
            public bool BoolValue = false;

            [SerializeField]
            public float FloatValue = 0f;
        }

        [SerializeField]
        private string _fileName = "SaveDataSample.json";

        [SerializeField]
        private Toggle _toggle = null;

        [SerializeField]
        private Slider _slider = null;

        private SimpleSaveDataController _saveDataController;

        private void Start()
        {
            _saveDataController = new SimpleSaveDataController(Application.persistentDataPath);
            if (_saveDataController.Exists(_fileName))
            {
                Load();
            }
            else
            {
                _toggle.isOn = false;
                _slider.value = 0f;
            }
        }

        public void Save()
        {
            var saveData = new SaveData
            {
                BoolValue = _toggle.isOn,
                FloatValue = _slider.value,
            };
            var json = JsonUtility.ToJson(saveData);
            var filePath = _saveDataController.SaveText(_fileName, json);
            Debug.Log($"Save to {filePath}");
        }

        public void Load()
        {
            var json = _saveDataController.LoadText(_fileName);
            var saveData = JsonUtility.FromJson<SaveData>(json);
            _toggle.isOn = saveData.BoolValue;
            _slider.value = saveData.FloatValue;
        }
    }
}
