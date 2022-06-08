﻿using System;
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
using WPF_Project.Models;

namespace WPF_Project
{
    /// <summary>
    /// Logika interakcji dla klasy Task.xaml
    /// </summary>
    public partial class Task : UserControl
    {
        public static readonly DependencyProperty BoardTask_Property = DependencyProperty.Register("BoardTask", typeof(BoardTask), typeof(Task));
        public BoardTask BoardTask
        {
            get => this.GetValue(BoardTask_Property) as BoardTask;
            set => this.SetValue(BoardTask_Property, value);
        }

        public Task()
        {
            InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
