using Biggy;
using Biggy.Core;
using Biggy.Data.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Input;
using WifeFlixUI.Models;

namespace WifeFlixUI.ViewModels
{
    public class SerieViewModel
    {
        private BiggyList<Serie> _serieList;
        public List<Serie> serieList;

        public SerieViewModel()
        {
            var _storeLocation = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "CONFIG");
            _serieList = new BiggyList<Serie>(new JsonStore<Serie>(_storeLocation, "Serie"));


            serieList = _serieList.ToList();

            //_serieList.Add(new Serie { SerieId = "1", SerieName = "Games of Throne", SerieSeasson = 10, SerieEpisode = 13 });
            //_serieList.Add(new Serie { SerieId = "2", SerieName = "Goldberg", SerieSeasson = 3, SerieEpisode = 3 });
            //_serieList.Add(new Serie { SerieId = "3", SerieName = "Vikings", SerieSeasson = 20, SerieEpisode = 12 });
            //_serieList.Add(new Serie { SerieId = "4", SerieName = "Big Ben Theory", SerieSeasson = 12, SerieEpisode = 11 });
            //_serieList.Add(new Serie { SerieId = "5", SerieName = "South Park", SerieSeasson = 20, SerieEpisode = 7 });
            //_serieList.Add(new Serie { SerieId = "6", SerieName = "Orange Black", SerieSeasson = 2, SerieEpisode = 20 });

            GetAllSerie();

            

        }


        public IQueryable<Serie> GetAllSerie()
        {

            return _serieList.AsQueryable<Serie>();
        }

        //Add Serie
        public Serie AddSerie(string serie, out bool isAddResult)
        {

            Serie newSerie = new Serie();
            int exist = _serieList.Count(c => c.SerieName == serie);

            if (exist < 1)
            {
                newSerie.SerieId = Guid.NewGuid().ToString();
                newSerie.SerieName = serie;
                newSerie.SerieSeasson = 1;
                newSerie.SerieEpisode = 1;

                _serieList.Add(newSerie);
                isAddResult = true;

            }
            else
            {
                isAddResult = false;
            }

            
            return newSerie;

        }

        //Update Serie
        public Serie UpdateSerie(Serie serie, out bool isUpdatedResult)
        {


            
            var serieUpdate = _serieList.SingleOrDefault(c => c.SerieId == serie.SerieId);
            serieUpdate.SerieName = serie.SerieName.ToString();
            serieUpdate.SerieSeasson = serie.SerieSeasson;
            serieUpdate.SerieEpisode = serie.SerieEpisode;


            _serieList.Update(serieUpdate);
            Console.WriteLine("Saved------------------------------------------------------------------------");

            isUpdatedResult = true;
            return serieUpdate;
        }

        //Delete Serie
        public Serie DeleteSerie(string Id, out bool isUpdatedResult)
        {
            var serieToDelete = _serieList.SingleOrDefault(c => c.SerieId == Id);

            _serieList.Remove(serieToDelete);
            isUpdatedResult = true;
            return serieToDelete;

        }


    }
}
