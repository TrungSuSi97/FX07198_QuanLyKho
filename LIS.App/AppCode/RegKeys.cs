using Microsoft.Win32;

namespace TPH.LIS.App.AppCode
{
    public class RegKeys
    {
        private string _userRoot;
        private string _subkey;
        private string _keyName;

        /// <summary>
        /// Đọc đường dẫn của Registry
        /// </summary>
        /// <param name="_localUser_0_LocalMachine_1">0: HKEY_CURRENT_USER, 1: HKEY_LOCAL_MACHINE </param>
        /// <param name="subKey">Đường dẫn cấp con</param>
        public RegKeys(int _localUser_0_LocalMachine_1, string subKey)
        {
            if (_localUser_0_LocalMachine_1 == 0)
            {
                _userRoot = "HKEY_CURRENT_USER";
            }
            else
            {
                _userRoot = "HKEY_LOCAL_MACHINE";
            }
            _subkey = subKey;
            _keyName = _userRoot + "\\" + _subkey;
        }
        /// <summary>
        /// Hàm ghi thông số lên registry
        /// </summary>
        /// <param name="_valueName">Tên</param>
        /// <param name="_value">Giá trị</param>
        public void WriteRegistry(string _valueName, string _value)
        {
            Registry.SetValue(_keyName, _valueName, _value, RegistryValueKind.String);
        }
        public void WirteRegistry_Dword(string _valueName, int _Value)
        {
            Registry.SetValue(_keyName, _valueName, unchecked((int)_Value), RegistryValueKind.DWord);
        }
        /// <summary>
        /// Hàm đọc thông số của registry
        /// </summary>
        /// <param name="_valueName">string valueName</param>
        /// <returns>Trả về giá trị</returns>
        public string ReadRegistry(string _valueName)
        {
            try
            {
                return Registry.GetValue(_keyName, _valueName, string.Empty).ToString();
            }
            catch
            {
                return null;
            }
        }
    }
}
