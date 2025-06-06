﻿using System.IO;
using Colossal.Logging;
using Game;
using Game.Modding;
using Game.SceneFlow;

namespace CustomAssetPack
{
    public class Mod : IMod
    {
        public static ILog log = LogManager.GetLogger($"AssetPacksManager.Packs")
            .SetShowsErrorsInUI(false);
        
        private string pathToModFolder;

        public void OnLoad(UpdateSystem updateSystem)
        {
            if (!GameManager.instance.modManager.TryGetExecutableAsset(this, out var asset)) return;

            pathToModFolder = $"{new FileInfo(asset.path).DirectoryName}";

            ExtraAssetsImporter.EAI.LoadCustomAssets(pathToModFolder);
        }

        public void OnDispose()
        {
            ExtraAssetsImporter.EAI.UnLoadCustomAssets(pathToModFolder);
        }
    }
}