using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace DynamicGridsColumns
{
    public class ListViewExtension
    {
        public static readonly DependencyProperty MatrixSourceProperty =
            DependencyProperty.RegisterAttached("MatrixSource", typeof(Grupa), typeof(ListViewExtension),
                new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnMatrixSourceChanged)));

        public static Grupa GetMatrixSource(DependencyObject obj)
        {
            return (Grupa)obj.GetValue(MatrixSourceProperty);
        }

        public static void SetMatrixSource(DependencyObject obj, Grupa value)
        {
            obj.SetValue(MatrixSourceProperty, value);
        }

        private static void OnMatrixSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ListView listView = d as ListView;
            Grupa grupa = e.NewValue as Grupa;

            listView.ItemsSource = grupa;
            GridView gridView = listView.View as GridView;
            //int count = 0;

            gridView.Columns.Clear();

            int maxAnswers = grupa.Pytania.Max(p => p.Odpowiedzi.Count);

            gridView.Columns.Add(
                new GridViewColumn()
                    {
                        DisplayMemberBinding = new Binding("Tresc")
                    });

            for (int i = 1; i < maxAnswers + 1; i++)
            {
                gridView.Columns.Add(
                    new GridViewColumn()
                        {
                            DisplayMemberBinding = new Binding("Tresc")
                        });
            }
        }
    }
}
