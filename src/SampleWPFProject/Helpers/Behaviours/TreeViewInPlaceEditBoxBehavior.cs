using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using WPFProject.Helpers.Extensions;

namespace WPFProject.Helpers.Behaviours
{
    public class TreeViewInPlaceEditBoxBehavior
    {
        public static readonly DependencyProperty IsEditingProperty 
            = DependencyProperty.RegisterAttached("IsEditing", typeof(bool), typeof(TreeViewInPlaceEditBoxBehavior), new PropertyMetadata(OnIsEditingChanged));

        public static bool GetIsEditing(DependencyObject obj)
            => (bool)obj.GetValue(IsEditingProperty);

        public static void SetIsEditing(DependencyObject obj, bool value)
            => obj.SetValue(IsEditingProperty, value);

        public static readonly DependencyProperty IsEditConfirmedProperty 
            = DependencyProperty.RegisterAttached("IsEditConfirmed", typeof(bool), typeof(TreeViewInPlaceEditBoxBehavior), new PropertyMetadata(OnIsEditConfirmedChanged));

        public static bool GetIsEditConfirmed(DependencyObject obj)
            => (bool)obj.GetValue(IsEditConfirmedProperty);

        public static void SetIsEditConfirmed(DependencyObject obj, bool value)
            => obj.SetValue(IsEditConfirmedProperty, value);

        public static readonly DependencyProperty IsEditCancelledProperty 
            = DependencyProperty.RegisterAttached("IsEditCancelled", typeof(bool), typeof(TreeViewInPlaceEditBoxBehavior), new PropertyMetadata(OnIsEditCancelledChanged));

        public static bool GetIsEditCancelled(DependencyObject obj)
            => (bool)obj.GetValue(IsEditCancelledProperty);

        public static void SetIsEditCancelled(DependencyObject obj, bool value)
            => obj.SetValue(IsEditCancelledProperty, value);

        private static void FocusAndSelect(TextBox textBox)
        {
            Keyboard.Focus(textBox);
            textBox.SelectAll();
        }

        private static void OnIsEditingChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            TextBox textBox = obj as TextBox;

            if (Equals(textBox, null))
            {
                throw new ArgumentException("obj is not a TextBox");
            }

            textBox.Dispatcher.BeginInvoke((Action) (() => FocusAndSelect(textBox)), DispatcherPriority.Loaded);
        }

        private static void OnIsEditConfirmedChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            TextBox textBox = obj as TextBox;

            if (Equals(textBox, null))
            {
                throw new ArgumentException("obj is not a TextBox");
            }

            if ((bool)args.NewValue && textBox.IsVisible)
            {
                textBox.UpdateBindingSource(TextBox.TextProperty);
            }
        }

        private static void OnIsEditCancelledChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            TextBox textBox = obj as TextBox;

            if (Equals(textBox, null))
            {
                throw new ArgumentException("obj is not a TextBox");
            }

            if ((bool)args.NewValue && textBox.IsVisible)
            {
                textBox.UpdateBindingTarget(TextBox.TextProperty);
            }
        }
    }
}