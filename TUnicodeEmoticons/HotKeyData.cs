using TUnicodeEmoticons.Infrastructure;

namespace TUnicodeEmoticons
{
    public class HotKeyData : PropertyChangedBase
    {
        private int _firstModifierIndex;
        private bool _hasFirstModifier;
        private int _secondModifierIndex;
        private bool _hasSecondModifier;
        private int _keyIndex;

        public HotKeyData(int firstModifierIndex, bool hasFirstModifier, int secondModifierIndex, bool hasSecondModifier, int keyIndexIndex)
        {
            FirstModifierIndex = firstModifierIndex;
            HasFirstModifier = hasFirstModifier;
            SecondModifierIndex = secondModifierIndex;
            HasSecondModifier = hasSecondModifier;
            KeyIndex = keyIndexIndex;
        }

        public int FirstModifierIndex
        {
            get { return _firstModifierIndex; }
            set
            {
                _firstModifierIndex = value;
                OnPropertyChanged();
            }
        }

        public bool HasFirstModifier
        {
            get { return _hasFirstModifier; }
            set
            {
                _hasFirstModifier = value;
                OnPropertyChanged();
            }
        }

        public int SecondModifierIndex
        {
            get { return _secondModifierIndex; }
            set
            {
                _secondModifierIndex = value;
                OnPropertyChanged();
            }
        }

        public bool HasSecondModifier
        {
            get { return _hasSecondModifier; }
            set
            {
                _hasSecondModifier = value;
                OnPropertyChanged();
            }
        }

        public int KeyIndex
        {
            get { return _keyIndex; }
            set
            {
                _keyIndex = value;
                OnPropertyChanged();
            }
        }
    }
}