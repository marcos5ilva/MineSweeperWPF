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
using System.Windows.Shapes;

namespace MineSweeperWPF
{
    /// <summary>
    /// Interaction logic for CustomWindow.xaml
    /// </summary>
    public partial class CustomWindow : Window
    {
        public CustomWindow()
        {
            InitializeComponent();
        }

        private void CustomPlay_Click(object sender, RoutedEventArgs e)
        {
            
            int gameLevelValue = 4;
            int number = 0;
            if (int.TryParse(NumberOfColumnsTextBox.Text, out number)&& int.TryParse(NumberOfRowsTextBox.Text, out number) && int.TryParse(NumberOfMinesTextBox.Text, out number)) {
                GameWindow gameWindow = new GameWindow(gameLevelValue, Int16.Parse(NumberOfColumnsTextBox.Text), Int16.Parse(NumberOfRowsTextBox.Text), Int16.Parse(NumberOfMinesTextBox.Text));
                this.Close();
                gameWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("You have to enter valid numbers for rows, columns, and number of mines!");
            }
        } 
    }
}
