using APILibrary;
using APILibrary.Models;
using APILibrary.Processors;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;

namespace MovieWPF.ViewModels
{
    public class ShellViewModel:Screen
    {
        public BindableCollection<MovieModel> Movies { get; set; }
        public ShellViewModel()
        {
            APIHelper.InitializeClient();
        }
        private string _searchTitle="";

        public string SearchTitle
        {
            get { return _searchTitle; }
            set { _searchTitle = value; }
        }
        private int _searchYear;

        public int SearchYear
        {
            get { return _searchYear; }
            set { _searchYear = value; }
        }

        private async Task LoadMovie(int movieId=0)
        {          
            Movies=  new BindableCollection<MovieModel>(await MovieProcessor.LoadMovie(SearchYear, SearchTitle));
            NotifyOfPropertyChange(() => Movies);           
        }

        // körs när amnändare trycker på sökknappen 
        public async void SearchButton()
        {
            try
            {
                await LoadMovie();
            }
            //catch (HttpException e)
            //{
            //    MessageBox.Show(e.Message, "Movie", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Movie", MessageBoxButton.OK, MessageBoxImage.Error);
            }

           
        }




    }
}
