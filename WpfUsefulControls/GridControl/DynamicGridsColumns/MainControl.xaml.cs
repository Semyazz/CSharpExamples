using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DynamicGridsColumns
{
    /// <summary>
    /// Interaction logic for MainControl.xaml
    /// </summary>
    public partial class MainControl
    {
        private IControlFactory controlsFactory;

        public IControlFactory ControlsFactory
        {
            get
            {
                if (controlsFactory == null)
                {
                    controlsFactory = new DefaultControlFactory();
                }
                return controlsFactory;
            }

            set
            {
                controlsFactory = value;
            }
        }

        public MainControl()
        {
            this.InitializeComponent();
        }

        private void GridDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (ControlsFactory == null)
            {
                throw new Exception("ControlsFactory is not setted");
            }

            Grid grid = sender as Grid;

            if (grid == null)
            {
                return;
            }

            grid.Children.Clear();
            grid.ColumnDefinitions.Clear();

            Grupa g = e.NewValue as Grupa;

            int maxColumns = g.Pytania.Max(p => p.Odpowiedzi.Count + 1);

            for (int i = 0; i < maxColumns; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition()
                                               {
                                               });
            }

            var pytania = g.Pytania;

            int columnPointer;

            //foreach (var pytanie in pytania)
            //{
            //    grid.RowDefinitions.Add(new RowDefinition()
            //                                {
            //                                    Height = GridLength.Auto
            //                                });
            //    columnPointer = 0;

            //    TextBlock tb = new TextBlock() { Text = pytanie.Tresc };
            //    tb.SetValue(Grid.ColumnProperty, columnPointer);
            //    tb.SetValue(Grid.RowProperty, grid.RowDefinitions.Count-1);
            //    columnPointer++;

            //    grid.Children.Add(tb);

            //    foreach (var odp in pytanie.Odpowiedzi)
            //    {
            //        TextBlock tblc = new TextBlock() { Text = odp.Tresc };
            //        tblc.SetValue(Grid.ColumnProperty, columnPointer);
            //        columnPointer++;
            //        tblc.SetValue(Grid.RowProperty, grid.RowDefinitions.Count - 1);
            //        grid.Children.Add(tblc);
            //    }

            //}

            foreach (var pytanie in pytania)
            {
                grid.RowDefinitions.Add(new RowDefinition()
                                            {
                                                Height = GridLength.Auto
                                            });
                columnPointer = 0;

                UIElement questionControl = ControlsFactory.CreateControl(pytanie);
                questionControl.SetValue(Grid.ColumnProperty, columnPointer);
                questionControl.SetValue(Grid.RowProperty, grid.RowDefinitions.Count - 1);
                columnPointer++;
                grid.Children.Add(questionControl);

                foreach (var odp in pytanie.Odpowiedzi)
                {
                    UIElement control = ControlsFactory.CreateControl(odp);
                    control.SetValue(Grid.ColumnProperty, columnPointer);
                    columnPointer++;
                    control.SetValue(Grid.RowProperty, grid.RowDefinitions.Count - 1);
                    grid.Children.Add(control);
                }
            }
        }
    }
}