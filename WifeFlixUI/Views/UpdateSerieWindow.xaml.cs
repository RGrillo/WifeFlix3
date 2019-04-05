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
using System.Windows.Shapes;
using WifeFlixUI.Models;
using WifeFlixUI.ViewModels;

namespace WifeFlixUI.Views
{
    /// <summary>
    /// Interaction logic for UpdateSerieWindow.xaml
    /// </summary>
    public partial class UpdateSerieWindow : Window
    {

        Serie serie;
        public UpdateSerieWindow(Serie serie)
        {
            InitializeComponent();


            if (serie == null)
            {
                serieNameTextBox.Text = "";
                seassonTextBox.Text = "";
                episodeTextBox.Text = "";
                serieIdTextBox.Text = "";
                this.Close();

            }
            else
            {
                this.serie = serie;
                serieNameTextBox.Text = serie.SerieName;
                seassonTextBox.Text = serie.SerieSeasson.ToString();
                episodeTextBox.Text = serie.SerieEpisode.ToString();
                serieIdTextBox.Text = serie.SerieId.ToString();

            }



        }

        private void UpdateSerieBtn_Click(object sender, RoutedEventArgs e)
        {

            string name = serieNameTextBox.Text;
            bool isUpdatedResult = false;

            var serie = new Serie();
            serie.SerieName = serieNameTextBox.Text;
            serie.SerieSeasson = Convert.ToInt32(seassonTextBox.Text);
            serie.SerieEpisode = Convert.ToInt32(episodeTextBox.Text);
            serie.SerieId = serieIdTextBox.Text;

            var serieVM = new SerieViewModel();
            serieVM.UpdateSerie(serie,out isUpdatedResult);

            if (isUpdatedResult == true)
            {
                this.Close();

                //MessageBox.Show("Serie " + name + " Updated");                
            }

        }

        private void DeleteSerieBtn_Click(object sender, RoutedEventArgs e)
        {
            string id = serieIdTextBox.Text;
            string name = serieNameTextBox.Text;
            bool isUpdatedResult = false;

            var svm = new SerieViewModel();
            var ds = new Serie();

            svm.DeleteSerie(id, out isUpdatedResult);


            if (isUpdatedResult == true)
            {
                this.Close();

                //MessageBox.Show("Serie " + name + " Deleted!");
 

            }
        }
    }
}
