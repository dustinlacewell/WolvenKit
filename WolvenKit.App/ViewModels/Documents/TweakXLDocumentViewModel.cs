using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Splat;
using WolvenKit.Core.Interfaces;
using WolvenKit.Common.Services;
using WolvenKit.Functionality.Services;
using WolvenKit.Models;
using WolvenKit.RED4.Types;
using WolvenKit.ViewModels.Documents;
using YamlDotNet.Serialization;

namespace WolvenKit.ViewModels.Documents
{
    public class TweakXLDocumentViewModel : RedDocumentViewModel
    {
        private TweakDBService _tdbs;
        private readonly ISettingsManager _settingsManager = Locator.Current.GetService<ISettingsManager>();
        

        public TweakXLDocumentViewModel(string path) : base(path)
        {
            _tdbs = Locator.Current.GetService<TweakDBService>();
        }

        private Task LoadTweakDB()
        {
            if (_tdbs.IsLoaded)
            {
                return Task.CompletedTask;
            }

            return _tdbs.LoadDB(Path.Combine(_settingsManager.GetRED4GameRootDir(), "r6", "cache", "tweakdb.bin"));
        }

        public override async Task<bool> OpenFileAsync(string path)
        {
            _isInitialized = false;

            // make sure TweakDB is loaded before we open the TweakXL file
            await Task.WhenAll(LoadTweakDB());

            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                FilePath = path;

                try
                {
                    // read tweakXL file
                    using var reader = new StreamReader(stream);
                    var deserializer = new DeserializerBuilder()
                        .WithTypeConverter(new TweakXLYamlTypeConverter())
                        .Build();
                    var file = deserializer.Deserialize<TweakXLFile>(reader);
                    TabItemViewModels.Add(new RDTDataViewModel(file, this));

                    // read text file
                    stream.Seek(0, SeekOrigin.Begin);
                    TabItemViewModels.Add(new RDTTextViewModel(stream, this));

                }
                catch (Exception ex)
                {
                    _loggerService.Error(ex);
                    return false;
                }

                _isInitialized = true;

                SelectedIndex = 0;
                SelectedTabItemViewModel = TabItemViewModels.FirstOrDefault();
            }

            return true;
        }
    }
}
