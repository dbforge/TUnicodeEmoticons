using System;
using System.ComponentModel;

namespace TUnicodeEmoticons.Infrastructure
{
    [Serializable]
    public class PropertyChangedBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual bool SetProperty<T>(T value, ref T field, string propertyName = null)
        {
            if (field != null && field.Equals(value))
                return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}