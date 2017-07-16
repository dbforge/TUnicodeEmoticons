using System.Windows.Input;
using TUnicodeEmoticons.Infrastructure;

namespace TUnicodeEmoticons
{
    public class HotKeyData : PropertyChangedBase
    {
        private int _firstModifierIndex;
        private bool _hasFirstModifier;
        private int _secondModifierIndex;
        private bool _hasSecondModifier;
        private Key _key;

        public HotKeyData(int firstModifierIndex, bool hasFirstModifier, int secondModifierIndex, bool hasSecondModifier, Key key)
        {
            FirstModifierIndex = firstModifierIndex;
            HasFirstModifier = hasFirstModifier;
            SecondModifierIndex = secondModifierIndex;
            HasSecondModifier = hasSecondModifier;
            Key = key;
        }

        public int FirstModifierIndex
        {
            get { return _firstModifierIndex; }
            set { SetProperty(value, ref _firstModifierIndex, nameof(FirstModifierIndex)); }
        }

        public bool HasFirstModifier
        {
            get { return _hasFirstModifier; }
            set { SetProperty(value, ref _hasFirstModifier, nameof(HasFirstModifier)); }
        }

        public int SecondModifierIndex
        {
            get { return _secondModifierIndex; }
            set { SetProperty(value, ref _secondModifierIndex, nameof(SecondModifierIndex)); }
        }

        public bool HasSecondModifier
        {
            get { return _hasSecondModifier; }
            set { SetProperty(value, ref _hasSecondModifier, nameof(HasSecondModifier)); }
        }

        public Key Key
        {
            get { return _key; }
            set { SetProperty(value, ref _key, nameof(Key)); }
        }
    }
}