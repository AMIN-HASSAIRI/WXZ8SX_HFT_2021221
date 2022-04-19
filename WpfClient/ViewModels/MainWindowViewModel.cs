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

        }
    }
}
