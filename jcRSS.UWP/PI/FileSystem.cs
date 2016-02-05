using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

using Windows.Security.Cryptography;
using Windows.Security.Cryptography.DataProtection;
using Windows.Storage;
using Windows.UI.Xaml;
using jcRSS.PCL.Enums;
using jcRSS.PCL.Objects.Common;
using jcRSS.PCL.PA;

namespace jcRSS.UWP.PI {
    public class FileSystem : BaseFileSystem {
        private StorageFolder SelectedStorageFolder => (_settings.GetSetting<bool>(SETTINGS.ENABLE_ROAMING)
            ? ApplicationData.Current.RoamingFolder
            : ApplicationData.Current.LocalFolder);

        public override async Task<string> GetLocalFile(string path) {
            var folder = await StorageFolder.GetFolderFromPathAsync(path);

            var file = await folder.GetFileAsync(path);

            return await FileIO.ReadTextAsync(file);
        }

        public override async Task<CTO<T>> GetFile<T>(FILE_TYPES fileType, bool encrypted = true) {
            var filesinFolder = await SelectedStorageFolder.GetFilesAsync();

            var file = filesinFolder.FirstOrDefault(a => a.Name == fileType.ToString());

            if (file == null) {
                return new CTO<T>(default(T), $"{fileType} was not found");
            }

            var buffer = await FileIO.ReadBufferAsync(file);

            if (encrypted) {
                var decrypted = await decryptData(buffer.ToArray());
                return new CTO<T>(GetObjectFromJSONString<T>(decrypted));
            }

            return new CTO<T>(GetObjectFromBytes<T>(buffer.ToArray()));
        }

        private async Task<byte[]> encryptData(string unencryptedData) {
            var Provider = new DataProtectionProvider("LOCAL=user");

            var buffMsg = CryptographicBuffer.ConvertStringToBinary(unencryptedData, BinaryStringEncoding.Utf8);

            var buffProtected = await Provider.ProtectAsync(buffMsg);

            return buffProtected.ToArray();
        }

        private async Task<string> decryptData(byte[] encryptedData) {
            var Provider = new DataProtectionProvider();

            var buffUnprotected = await Provider.UnprotectAsync(CryptographicBuffer.CreateFromByteArray(encryptedData));

            return CryptographicBuffer.ConvertBinaryToString(BinaryStringEncoding.Utf8, buffUnprotected);
        }

        public override async Task<CTO<bool>> WriteFile<T>(FILE_TYPES fileType, T obj, bool encryptFile = true) {
            var str = GetJSONStringFromT(obj);

            byte[] data;

            if (encryptFile) {
                data = await encryptData(str);
            } else {
                data = GetBytesFromT(obj);
            }

            using (var stream = await SelectedStorageFolder.OpenStreamForWriteAsync(fileType.ToString(), CreationCollisionOption.ReplaceExisting)) {
                stream.Write(data, 0, data.Length);
            }

            return new CTO<bool>(true);
        }

        public FileSystem(BaseNetwork network, SettingsContainer settings) : base(network, settings) {
        }
    }
}