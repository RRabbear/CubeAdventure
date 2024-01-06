using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Assets.Scripts.Gameplay.LevelLogic;
using System.Collections.Generic;
using Assets.Scripts.Core;

namespace Assets.Scripts.Gameplay.SaveSystem
{
    public static class SaveSystem
    {
        public static void SaveLevelData(Dictionary<LevelLists.ELevels, LevelManager.ELevelState> dic)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/SavedLevelData";

            FileStream stream = new FileStream(path, FileMode.Create);

            SavedLevelData data = new SavedLevelData(dic);

            formatter.Serialize(stream, data);
            stream.Close();
        }

        public static SavedLevelData LoadLevelData()
        {
            string path = Application.persistentDataPath + "/SavedLevelData";
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                SavedLevelData data = formatter.Deserialize(stream) as SavedLevelData;
                stream.Close();

                return data;
            }
            else
            {
                if (GameManager.Instance.levelStateDic == null)
                {
                    GameManager.Instance.InitializeLevelStateDic();
                }

                SaveLevelData(GameManager.Instance.levelStateDic);
                return LoadLevelData();
            }
        }
    }
}