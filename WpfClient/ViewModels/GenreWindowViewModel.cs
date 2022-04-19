using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfClient.Clients;
using WXZ8SX_HFT_2021221.Models;

namespace WpfClient.ViewModels
{
    public class GenreWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }


        public RestCollection<Genre> Genre { get; set; }

        private Genre selectedGenre;
        public Genre SelectedGenre
        {
            get { return selectedGenre; }
            set
            {
                if (value != null)
                {
                    selectedGenre = new Genre()
                    {
                        GenreId = value.GenreId,
                        GenreName = value.GenreName,
                    };
                    OnPropertyChanged();
                    (DeleteGenreCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand AddGenreCommand { get; set; }

        public ICommand DeleteGenreCommand { get; set; }

        public ICommand EditGenreCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public GenreWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Genre = new RestCollection<Genre>("http://localhost:49755/", "genre", "hub");
                AddGenreCommand = new RelayCommand(() =>
                {
                    Genre.Add(new Genre()
                    {
                        GenreId = SelectedGenre.GenreId,
                        GenreName = SelectedGenre.GenreName,
                    });
                });

                EditGenreCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Genre.Update(SelectedGenre);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteGenreCommand = new RelayCommand(() =>
                {
                    Genre.Delete(SelectedGenre.GenreId);
                },
                () =>
                {
                    return SelectedGenre != null;
                });
                SelectedGenre = new Genre();
            }
        }
    }
}
