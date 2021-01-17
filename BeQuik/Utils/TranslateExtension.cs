using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BeQuik.Utils
{
    [ContentProperty(nameof(InputView.Text))]
    public class TranslateExtension : IMarkupExtension<BindingBase>
    {
        public string Text { get; set; }
        public string StringFormat { get; set; }
        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            try
            {
                return ProvideValue(serviceProvider);
            }
            catch
            {
                return Text;
            }
        }

        public BindingBase ProvideValue(IServiceProvider serviceProvider)
        {
            var binding = new Binding
            {
                Mode = BindingMode.OneWay,
                Path = $"[{Text}]",
                Source = LocalizationResourceManager.Instance,
                StringFormat = StringFormat

            };
            return binding;

        }
    }
}