using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using System.Windows.Interop;
using TUnicodeEmoticons.Win32;

namespace TUnicodeEmoticons
{
    public class HotKey : IDisposable
    {
        private static Dictionary<int, HotKey> _dictHotKeyToCalBackProc;

        public const int WM_HOT_KEY = 0x0312;
        private bool _disposed;

        public Key Key { get; }
        public KeyModifiers KeyModifiers { get; set; }
        public Action<HotKey> Action { get; set; }
        public int Id { get; set; }

        public HotKey(Key k, KeyModifiers keyModifiers, bool register = true)
        {
            Key = k;
            KeyModifiers = keyModifiers;
            if (register)
                Register();
        }

        ~HotKey()
        {
            Dispose();
        }

        public bool Register()
        {
            int virtualKeyCode = KeyInterop.VirtualKeyFromKey(Key);
            Id = virtualKeyCode + ((int)KeyModifiers * 0x10000);
            bool result = NativeMethods.RegisterHotKey(IntPtr.Zero, Id, (uint)KeyModifiers, (uint)virtualKeyCode);

            if (_dictHotKeyToCalBackProc == null)
            {
                _dictHotKeyToCalBackProc = new Dictionary<int, HotKey>();
                ComponentDispatcher.ThreadFilterMessage += ComponentDispatcherThreadFilterMessage;
            }

            Debug.Print(result.ToString());
            _dictHotKeyToCalBackProc.Add(Id, this);
            return result;
        }

        public void Unregister()
        {
            HotKey hotKey;
            if (_dictHotKeyToCalBackProc.TryGetValue(Id, out hotKey))
            {
                NativeMethods.UnregisterHotKey(IntPtr.Zero, Id);
                _dictHotKeyToCalBackProc.Remove(Id);
            }
        }

        private static void ComponentDispatcherThreadFilterMessage(ref MSG msg, ref bool handled)
        {
            if (handled || msg.message != WM_HOT_KEY)
                return;

            HotKey hotKey;
            if (!_dictHotKeyToCalBackProc.TryGetValue((int)msg.wParam, out hotKey))
                return;
            hotKey.Action?.Invoke(hotKey);
            handled = true;
        }

        public static int FindKeyIndex(Key key)
        {
            return Array.FindIndex(Enum.GetValues(typeof(Key)).Cast<Key>().ToArray(), k => k == key);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
                Unregister();

            _disposed = true;
        }
    }
}