using System.Windows;

namespace WPFProject.Helpers.Tools
{
    /// <summary>
    /// BindingProxy class for elements which DataContext is not inherited in WPF
    /// </summary>
    public class BindingProxy : Freezable
    {
        /// <summary>
        /// Initializes a new instance 
        /// </summary>
        protected override Freezable CreateInstanceCore()
            => new BindingProxy();

        /// <summary>
        /// Gets or sets proxy data
        /// </summary>
        public object Data
        {
            get => GetValue(DataProperty); 
            set => SetValue(DataProperty, value); 
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for Data. This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty DataProperty =
            DependencyProperty.Register("Data", typeof(object), typeof(BindingProxy), new UIPropertyMetadata(null));
    }
}
