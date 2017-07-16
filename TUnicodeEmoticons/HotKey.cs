using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using System.Windows.Interop;
using TUnicodeEmoticons.Win32;

namespace TUnicodeEmoticons
{
    public class HotKey : IDisposable
    {
        // ReSharper disable once InconsistentNaming
        private const int WM_HOTKEY = 0x0312;

        private static readonly Dictionary<int, HotKey> RegisteredHotKeys = new Dictionary<int, HotKey>();
        private bool _disposed;

        static HotKey()
        {
            ComponentDispatcher.ThreadFilterMessage += ComponentDispatcherThreadFilterMessage;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="HotKey"/> class.
        /// </summary>
        /// <param name="key">The key to register.</param>
        /// <param name="keyModifiers">The modifiers of the key.</param>
        /// <param name="register">A value indicating whether the key should be registered directly, or not.</param>
        public HotKey(Key key, KeyModifiers keyModifiers, bool register = true)
        {
            Key = key;
            KeyModifiers = keyModifiers;

            if (register)
                Register();
        }

        /// <summary>
        ///     Gets or sets the <see cref="System.Action"/> that should be executed when the hotkey is pressed.
        /// </summary>
        public Action<HotKey> Action { get; set; }

        // ReSharper disable once InconsistentNaming
        /// <summary>
        ///     Gets the identifier of the hotkey.
        /// </summary>
        public int ID => KeyInterop.VirtualKeyFromKey(Key) + (int)KeyModifiers * 0x10000;

        /// <summary>
        ///     Gets the key of the hotkey.
        /// </summary>
        public Key Key { get; }

        /// <summary>
        ///     Gets the key modifiers of the hotkey.
        /// </summary>
        public KeyModifiers KeyModifiers { get; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private static void ComponentDispatcherThreadFilterMessage(ref MSG msg, ref bool handled)
        {
            if (handled || msg.message != WM_HOTKEY)
                return;

            HotKey hotKey;
            if (!RegisteredHotKeys.TryGetValue((int) msg.wParam, out hotKey))
                return;
            hotKey.Action?.Invoke(hotKey);
            handled = true;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
                Unregister();

            _disposed = true;
        }

        ~HotKey()
        {
            Dispose();
        }

        /// <summary>
        ///     Registers the hotkey.
        /// </summary>
        /// <returns>A value indicating whether the registration has been successful, or not.</returns>
        public bool Register()
        {
            // Register the hotkey.
            var result = NativeMethods.RegisterHotKey(IntPtr.Zero, ID, (uint) KeyModifiers, (uint)KeyInterop.VirtualKeyFromKey(Key));
            Debug.Print($"Registered the hot key: {result}");

            // Associate the ID of this key combination with the current hotkey.
            RegisteredHotKeys.Add(ID, this);
            return result;
        }

        /// <summary>
        ///     Unregisters the hotkey.
        /// </summary>
        public void Unregister()
        {
            HotKey hotKey;
            if (!RegisteredHotKeys.TryGetValue(ID, out hotKey))
                return;

            // Unregister the hotkey.
            NativeMethods.UnregisterHotKey(IntPtr.Zero, ID);
            RegisteredHotKeys.Remove(ID);
        }
    }
}