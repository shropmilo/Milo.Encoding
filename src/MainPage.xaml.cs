using System.Collections.ObjectModel;
using Milo.Core;
using Milo.Core.Encoding;
using Milo.Encoding.ViewModels;

namespace Milo.Encoding
{
    public interface IMiloSection
    {
        object Header { get; }
    }

    public partial class MainPage
    {
        private string _message = "Enter message here to be encoded";
        private string? _encryptedMessage;

        private readonly DeferredAction _encrypt;
        private EncoderViewModel? _selectedEncoder;

        private static IEncodingService? Service => MiloCore.GetService<IEncodingService>();

        /// <summary>
        /// Available encoders
        /// </summary>
        public ObservableCollection<EncoderViewModel> Encoders { get; } = new();

        /// <summary>
        /// Currently selected encoder
        /// </summary>
        public EncoderViewModel? SelectedEncoder
        {
            get => _selectedEncoder;
            set
            {
                if (Equals(value, _selectedEncoder)) return;
                _selectedEncoder = value;
                Encode();
                OnPropertyChanged();
            }
        }

        public string Message
        {
            get => _message;
            set
            {
                if (value == _message) return;
                _message = value;
                Encode();
                OnPropertyChanged();
            }
        }

        public string? EncryptedMessage
        {
            get => _encryptedMessage;
            set
            {
                if (value == _encryptedMessage) return;
                _encryptedMessage = value;
                OnPropertyChanged();
            }
        }

        public MainPage()
        {
            InitializeComponent();
            _encrypt = new DeferredAction(UpdateEncodedMessage);
            Loaded += OnLoaded;
        }

        private void Encode()
        {
            _encrypt.Defer(TimeSpan.FromMicroseconds(100));
        }
        private void UpdateEncodedMessage()
        {
            if (Service != null && SelectedEncoder != null)
            {
                EncryptedMessage = Service.EncodeMessage(SelectedEncoder.Key, Message);
            }
        }

        /// <summary>
        /// Load the Encoder keys async
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnLoaded(object? sender, EventArgs e)
        {
            try
            {
                await Task.Run(() =>
                {
                    var service = MiloCore.GetService<IEncodingService>();
                    if (service != null)
                    {
                        int count = 1;
                        foreach (var encoderKey in service.Keys)
                        {
                            Encoders.Add(new EncoderViewModel(encoderKey, $"Key {count}"));
                            count++;
                        }
                    }

                    SelectedEncoder = Encoders.FirstOrDefault();
                });
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex);
            }
        }

        /// <summary>
        /// Update to the selected EncoderKey model
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnKeyTapped(object? sender, TappedEventArgs e)
        {
            if (e.Parameter is EncoderViewModel encoder)
            {
                SelectedEncoder = encoder;
            }
        }
    }
}
