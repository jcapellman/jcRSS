using System.Threading.Tasks;

using jcRSS.PCL.Enums;
using jcRSS.PCL.Objects.Common;

namespace jcRSS.PCL.PA {
    public abstract class BaseFileSystem : BasePA {
        public abstract Task<CTO<T>> GetFile<T>(FILE_TYPES fileType, bool encryptedFile = true);

        public abstract Task<CTO<bool>> WriteFile<T>(FILE_TYPES fileType, T obj, bool encryptFile = true);

        public abstract Task<string> GetLocalFile(string path);
    }
}