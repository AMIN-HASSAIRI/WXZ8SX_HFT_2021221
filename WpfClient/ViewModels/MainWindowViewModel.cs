using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfClient.ViewModels
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public RelayCommand ManageAlbumsCommand { get; set; }
        public RelayCommand ManageArtistsCommand { get; set; }
        public RelayCommand ManageGenreCommand { get; set; }
        public RelayCommand ManageSongsCommand { get; set; }

        public RelayCommand ManageNonCrudAlbumsCommand { get; set; }
        public RelayCommand ManageNonCrudArtistsCommand { get; set; }
        public RelayCommand ManageNonCrudGenreCommand { get; set; }
        public RelayCommand ManageNonCrudSongsCommand { get; set; }

        public MainWindowViewModel()
        {
            ManageAlbumsCommand = new RelayCommand(OpenAlbumsWindow);
            ManageArtistsCommand = new RelayCommand(OpenArtistsWindow);
            ManageGenreCommand = new RelayCommand(OpenGenreWindow);
            ManageSongsCommand = new RelayCommand(OpenSongWindow);


            ManageNonCrudAlbumsCommand = new RelayCommand(OpenNonCrudAlbumsWindow);
            ManageNonCrudArtistsCommand = new RelayCommand(OpenNonCrudArtistsWindow);
            ManageNonCrudGenreCommand = new RelayCommand(OpenNonCrudGenreWindow);
            ManageNonCrudSongsCommand = new RelayCommand(OpenNonCrudSongsWindow);
        }

        private void OpenAlbumsWindow()
        {
            new AlbumsWindow().Show();
        }
        private void OpenArtistsWindow()
        {
            new ArtistsWindow().Show();
        }
        private void OpenGenreWindow()
        {
            new GenreWindow().Show();
        }
        private void OpenSongWindow()
        {
            new SongsWindow().Show();
        }


        private void OpenNonCrudAlbumsWindow()
        {
            new AlbumsNonCrudWindow().Show();
        }
        private void OpenNonCrudArtistsWindow()
        {
            new ArtistsNonCrudWindow().Show();
        }
        private void OpenNonCrudGenreWindow()
        {
            new GenreNonCrudWindow().Show();
        }
        private void OpenNonCrudSongsWindow()
        {
            new SongsNonCrudWindow().Show();
        }
    }
}
