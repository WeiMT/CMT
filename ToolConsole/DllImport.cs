using System.Runtime.InteropServices;

namespace ToolConsole
{
    public class DllImportCl
    {
        [DllImport("SM3.dll", EntryPoint = "?sm3_crypt_hash@SM3@@QAEXPAEQAEH@Z")]
        public static extern void sm3_crypt_hash(byte[] input, byte[] output, int len);
    }
}