﻿using Entity;
using Semama06.Model;
using Semama06.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Semama06.ViewModel
{
    public class ListaCategoriaViewModel : ViewModelBase
    {

        public Categoria _SelectedCategoria;
        public Categoria SelectedCategoria
        {
            get { return _SelectedCategoria; }
            set
            {
                if (_SelectedCategoria != value)
                {
                    _SelectedCategoria = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<Categoria> _Categorias;
        public ObservableCollection<Categoria> Categorias
        {
            get { return _Categorias; }
            set
            {
                if (Categorias != value)
                {
                    _Categorias = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand NuevoCommand { get; set; }
        public ICommand ConsultarCommand { get; set; }

        public ListaCategoriaViewModel()
        {
            Categorias = new CategoriaModel().Categorias;
            NuevoCommand = new RelayCommand<Window>(param => Abrir());
            ConsultarCommand = new RelayCommand<object>(o => { Categorias = (new CategoriaModel()).Categorias; });

        }

        void Abrir()
        {
            ManCategoria window = new ManCategoria(new Categoria());
            window.Show();
        }
    }
}
