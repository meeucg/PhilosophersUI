using Microsoft.Maui.Graphics.Text;
using Microsoft.Maui.Layouts;
using Contracts;
using PhilosophersMAUI;

namespace PhilosophersMAUI
{
    public partial class MainPage : ContentPage
    {
        int[] colors = { 1, 1, 1, 1, 1, 1, 1 };
        Color[] CurrentTheme = Themes.Theme1;

        public void ChangeThemeTo2()
        { 
            CurrentTheme = Themes.Theme2;
        }
        public void ChangeThemeTo1()
        {
            CurrentTheme = Themes.Theme1;
        }

        /*EventHandler ChangeColor(int buttonId)
        {
            
            EventHandler handler = (object? sender, EventArgs e) =>
            {
                if (sender is Button n)
                {
                    numbers[buttonId] = (numbers[buttonId]+1) % CurrentTheme.Length;
                    n.BackgroundColor = CurrentTheme[numbers[buttonId]];
                    n.TextColor = CurrentTheme[numbers[buttonId]];
                }
            };
            return handler;
        }*/

        public MainPage()
        {
            InitializeComponent();

            var table = new TableUI(7,80,30, 500);
            table.action += (object? sender, int buttonId) =>
            {
                if (sender is Button n)
                {
                    colors[buttonId] = (colors[buttonId] + 1) % CurrentTheme.Length;
                    n.BackgroundColor = CurrentTheme[colors[buttonId]];
                    n.TextColor = CurrentTheme[colors[buttonId]];
                }
            };
            var tableLayout = table.GetLayout;
            tableLayout.VerticalOptions = LayoutOptions.Center;
            tableLayout.HorizontalOptions = LayoutOptions.Center;

            Button iterateButon = new Button
            {
                Text = "Iterate",
                BackgroundColor = Colors.Black,
                TextColor = Colors.White,
                CornerRadius = 30,
                HeightRequest = 75,
                WidthRequest = 150
            };

            var mainLayout = new Grid();

            var functionalStack = new VerticalStackLayout
            {
                Spacing = 50,
                Padding = 50,
                VerticalOptions = LayoutOptions.Center
            };

            functionalStack.Add(tableLayout);
            functionalStack.Add(iterateButon);

            mainLayout.Add( functionalStack, 0, 0 );
            mainLayout.Add(new BoxView 
            { 
                BackgroundColor = Colors.Silver
            },
            1, 0);

            var scroll = new ScrollView
            {
                Content = mainLayout
            };

            Content = scroll;
        }
    }
}
