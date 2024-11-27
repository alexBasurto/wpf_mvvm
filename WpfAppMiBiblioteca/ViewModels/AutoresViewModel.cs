using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppMiBiblioteca.Models;
using WpfAppMiBiblioteca.Services;



namespace WpfAppMiBiblioteca.ViewModels
{
    class AutoresViewModel : INotifyPropertyChanged
    {
        private readonly DAL _DAL;

        public ObservableCollection<Autores> Autores { get; set; }

        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));

            }
        }

        public AutoresViewModel(DAL dal)
        {
            _DAL = dal;
            Autores = new ObservableCollection<Autores>();
            CargarAutores();
        }

        public async void CargarAutores()
        {
            IsLoading = true;
            try
            {
                var autoresList = await _DAL.ObtenerAutores();
                Autores.Clear();
                foreach (var autor in autoresList)
                {
                    Autores.Add(autor);
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores. Por ejemplo, log o mostrar un mensaje al usuario.
            }
            finally
            {
                IsLoading = false;
            }
        }

        // Implementación de INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
