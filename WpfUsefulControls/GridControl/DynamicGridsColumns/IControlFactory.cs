using System.Windows;

namespace DynamicGridsColumns
{
    public interface IControlFactory
    {
        UIElement CreateControl(object model);
    }
}
