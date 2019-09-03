using System.Windows;

namespace WPFProject.Helpers.Extensions
{
    public static class FrameworkElementExtension
    {
        public static void UpdateBindingTarget(this FrameworkElement element, DependencyProperty property)
        {
            var bindingExpr = element.GetBindingExpression(property);
            if (bindingExpr != null)
            {
                bindingExpr.UpdateTarget();
            }
        }

        public static void UpdateBindingSource(this FrameworkElement element, DependencyProperty property)
        {
            var bindingExpr = element.GetBindingExpression(property);
            if (bindingExpr != null)
            {
                bindingExpr.UpdateSource();
            }
        }
    }
}