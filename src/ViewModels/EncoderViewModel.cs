using Milo.Core;
using Milo.Core.Encoding;

namespace Milo.Encoding.ViewModels
{
    public class EncoderViewModel : PropertyChangedBase
    {
        public object Title { get; }

        public IEncoderKey Key { get; }

        public EncoderViewModel(IEncoderKey key, object title)
        {
            Title = title;
            Key = key;
        }
    }
}
