using System;
using Cysharp.Threading.Tasks;

namespace Glitch9.IO.Files
{
    [Serializable]
    public class UnityFile : UnityFileBase<byte[]>
    {
        protected override async UniTask<byte[]> LoadFileAsync() => await BinaryConverter.LoadBytes(Path);
        protected override byte[] ToBytes() => Value;
    }
}