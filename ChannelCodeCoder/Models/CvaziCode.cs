﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ChannelCodesCoder.Models
{
    public class CvaziCode : ChanelCode
    {
        public CvaziCode(string input)
        {
            InputInfo = input;
            ImpulseIsUp = true;
        }

        private bool ImpulseIsUp { get; set; }

        public Grid Interpret()
        {
            Grid grid = new Grid();
            grid.Height = 80;
            grid.Width = 0;
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            for (int i = 0; i < InputInfo.Length; i++)
            {
                if (InputInfo[i] == '0')
                {
                    grid.ColumnDefinitions.Add(new ColumnDefinition());
                    Line line = new Line() { StrokeThickness = 2.0, Margin = new System.Windows.Thickness(-1), Stroke = Brushes.Red, VerticalAlignment = VerticalAlignment.Top, Stretch = Stretch.Fill, X1 =1 };
                    Grid.SetColumn(line, i*2);
                    Grid.SetRow(line, 1);
                    grid.Children.Add(line);
                    grid.Width += 20;

                    Line line2 = new Line() { StrokeThickness = 2.0, Margin = new System.Windows.Thickness(-1), Stroke = Brushes.Red, VerticalAlignment = VerticalAlignment.Top, Stretch = Stretch.Fill, X1 = 1 };
                    grid.ColumnDefinitions.Add(new ColumnDefinition());                    
                    Grid.SetColumn(line2, i * 2+1);
                    Grid.SetRow(line2, 1);
                    grid.Children.Add(line2);
                    grid.Width += 20;
                }
                else if (InputInfo[i] == '1')
                {
                    grid.ColumnDefinitions.Add(new ColumnDefinition());
                    Border border;
                    if (ImpulseIsUp)
                    {
                        border = new Border() { BorderThickness = new System.Windows.Thickness(2, 2, 2, 0), BorderBrush = Brushes.Red, Margin = new System.Windows.Thickness(-1) };
                        Grid.SetColumn(border, i*2);
                        Grid.SetRow(border, 0);
                        ImpulseIsUp = false;
                    }
                    else
                    {
                        border = new Border() { BorderThickness = new System.Windows.Thickness(2, 0, 2, 2), BorderBrush = Brushes.Red, Margin = new System.Windows.Thickness(-1) };
                        Grid.SetColumn(border, i*2);
                        Grid.SetRow(border, 1);
                        ImpulseIsUp = true;
                    }
                    grid.Children.Add(border);
                    grid.Width += 20;

                    grid.ColumnDefinitions.Add(new ColumnDefinition());
                    Line line = new Line() { StrokeThickness = 2.0, Margin = new System.Windows.Thickness(-1), Stroke = Brushes.Red, VerticalAlignment = VerticalAlignment.Top, Stretch = Stretch.Fill, X1 = 1 };
                    Grid.SetColumn(line, i * 2+1);
                    Grid.SetRow(line, 1);
                    grid.Children.Add(line);
                    grid.Width += 20;
                }

            }
            return grid;
        }
    }
}
