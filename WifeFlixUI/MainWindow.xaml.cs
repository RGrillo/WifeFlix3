using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WifeFlixUI.Models;
using WifeFlixUI.ViewModels;
using WifeFlixUI.Views;

namespace WifeFlixUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new SerieViewModel();



        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


            var sl = new SerieViewModel();

            serieListView.ItemsSource = sl.serieList;


        }

        private void CreateNewSerieBtn_Click(object sender, RoutedEventArgs e)
        {
            bool isAddResult = false;
            var serie = new SerieViewModel();
            


            if (AddSerieBox.Text == "")
            {

            }
            else
            {
                serie.AddSerie(AddSerieBox.Text, out isAddResult);
                if (isAddResult == true)
                {
                    serie.AddSerie(AddSerieBox.Text, out isAddResult);
                    MessageBox.Show($"Serie : {AddSerieBox.Text} was added!");
                    AddSerieBox.Text = "";

                    var sl = new SerieViewModel();
                    serieListView.ItemsSource = sl.serieList;

                }
                else
                {
                    MessageBox.Show($"Serie : {AddSerieBox.Text} already Exist!");
                    AddSerieBox.Text = "";
                }

            }





        }


        private void SerieListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Serie selectedSerie = (Serie)serieListView.SelectedItem;

            UpdateSerieWindow uw = new UpdateSerieWindow(selectedSerie);
            Application.Current.MainWindow = uw;
            uw.ShowDialog();


            var sl = new SerieViewModel();
            this.serieListView.ItemsSource = sl.serieList;

        }
    }
}
