using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace DynamicGridsColumns
{
    public class DefaultControlFactory : IControlFactory
    {
        public UIElement CreateControl(object model)
        {
            Type modelType = model.GetType();
            UIElement control = null;

            if (modelType == typeof(Pytanie))
            {
                var pytanie = model as Pytanie;
                control = new TextBlock()
                              {
                                  Text = pytanie.Tresc
                              };
            }
            else if (modelType == typeof(Odpowiedz))
            {
                var odpowiedz = model as Odpowiedz;
                control = new TextBlock()
                {
                    Text = odpowiedz.Tresc
                };

            }
            else
            {
                throw new Exception("Undefined type of model");
            }

            return control;
        }
    }
}
