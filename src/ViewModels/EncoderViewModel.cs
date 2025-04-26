using Milo.Core;
using Milo.Core.Encoding;

namespace Milo.Apps.Encoding.MAUI.ViewModels
{
    public class EncoderViewModel(IEncoderKey key, object title) : PropertyChangedBase
    {
        public object Title { get; } = title;

        public IEncoderKey Key { get; } = key;
    }
}
