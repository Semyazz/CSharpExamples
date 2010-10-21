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
        public MainControl()
        {
            this.InitializeComponent();
            //this.DataContextChanged += new DependencyPropertyChangedEventHandler(MainControl_DataContextChanged);
        }

        private void Grid_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Grid grid = sender as Grid;

            if (grid == null)
            {
                return;
            }

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

            foreach (var pytanie in pytania)
            {
                grid.RowDefinitions.Add(new RowDefinition()
                                            {
                                                Height = GridLength.Auto
                                            });
                columnPointer = 0;

                TextBlock tb = new TextBlock() { Text = pytanie.Tresc };
                tb.SetValue(Grid.ColumnProperty, columnPointer);
                tb.SetValue(Grid.RowProperty, grid.RowDefinitions.Count-1);
                columnPointer++;

                grid.Children.Add(tb);

                foreach (var odp in pytanie.Odpowiedzi)
                {
                    TextBlock tblc = new TextBlock() { Text = odp.Tresc };
                    tblc.SetValue(Grid.ColumnProperty, columnPointer);
                    columnPointer++;
                    tblc.SetValue(Grid.RowProperty, grid.RowDefinitions.Count - 1);
                    grid.Children.Add(tblc);
                }
                              
            }
        }

        private void ItemsControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //ItemsControl control = sender as ItemsControl;
            //var grupa  = e.NewValue as Grupa;

            //if (grupa == null || control == null)
            //{
            //    return;
            //}

            //var pytania = grupa.Pytania;

            //int columnPointer;

            //control.Items.Clear();

            //foreach (var pytanie in pytania)
            //{
            //    ContainerVisual objects = new ContainerVisual();
            //    columnPointer = 0;

            //    TextBlock tb = new TextBlock() { Text = pytanie.Tresc};
            //    tb.SetValue(Grid.ColumnProperty, columnPointer);
            //    columnPointer++;

            //    objects.Children.Add(tb);

            //    foreach (var odp in pytanie.Odpowiedzi)
            //    {
            //        TextBlock tblc = new TextBlock() { Text = odp.Tresc };
            //        tblc.SetValue(Grid.ColumnProperty, columnPointer);
            //        columnPointer++;
            //        objects.Children.Add(tblc);
            //    }
            //    control.Items.Add(objects);
            //}
            

        }

        private void ListBox_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        //void MainControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        //{
        //    var grid = sender as Grid;

        //    if (grid == null)
        //    {
        //        return;
        //    }

        //    if (e.NewValue == null)
        //        return;

        //    var dataContext = e.NewValue as Grupa;

        //    int maxColumns = dataContext.Pytania.Max(p => p.Odpowiedzi.Count);


        //    CreateQuestionColumn(grid);
        //    CreateAnswersColumns(grid, maxColumns);
        //    FillGrid(grid, dataContext.Pytania, maxColumns);

        //}

        //private void FillGrid(Grid grid, List<Pytanie> pytania, int maxColumns)
        //{
        //    foreach (var pytanie in pytania)
        //    {
        //        grid.RowDefinitions.Add(new RowDefinition());

        //        int rowPointer = grid.RowDefinitions.Count - 1;
        //        int columnPointer = 0;

        //        TextBlock tb = new TextBlock()
        //                           {
        //                               TextWrapping = TextWrapping.WrapWithOverflow,
        //                               Text = pytanie.Tresc
        //                           };
        //        tb.SetValue(Grid.RowProperty, rowPointer);
        //        tb.SetValue(Grid.ColumnProperty, columnPointer);
        //        columnPointer++;
        //        grid.Children.Add(tb);

        //        for (int i = columnPointer; i < maxColumns+1; i++)
        //        {

        //            string tresc = "-";

        //            if (pytanie.Odpowiedzi.Count < i)
        //            {
        //                tresc = pytanie.Odpowiedzi[i].Tresc;
        //            }

        //            TextBlock answer = new TextBlock()
        //                                   {
        //                                       TextWrapping = TextWrapping.WrapWithOverflow,
        //                                       Text = tresc
        //                                   };
        //            tb.SetValue(Grid.RowProperty, rowPointer);
        //            tb.SetValue(Grid.ColumnProperty, i);
        //        }


        //    }
        //}

        //private void CreateAnswersColumns(Grid grid, int maxColumns)
        //{
        //    for (int i = 0; i < maxColumns; i++)
        //    {
        //        grid.ColumnDefinitions.Add(new ColumnDefinition()
        //                                       {
        //                                           Width = GridLength.Auto
        //                                       });
        //    }
        //}

        //private void CreateQuestionColumn(Grid grid)
        //{
        //    grid.ColumnDefinitions.Add(new ColumnDefinition()
        //                                   {
        //                                       Width = GridLength.Auto
        //                                   });
        //}

        //private static object GetPropertyValue(object obj, string propertyName)
        //{
        //    if (obj != null)
        //    {
        //        PropertyInfo prop = obj.GetType().GetProperty(propertyName);
        //        if (prop != null)
        //            return prop.GetValue(obj, null);
        //    }
        //    return null;
        //}


    }
}